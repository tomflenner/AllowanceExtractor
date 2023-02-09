using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using iTextSharp.text.pdf;

namespace AllowanceExtractor.Function;

public static class PdfParsing
{
    public static async Task<IEnumerable<Allowance>> ParsePdf(HttpContent responseContent)
    {
        var allowances = new List<Allowance>();

        var pdfStream = await responseContent.ReadAsStreamAsync();

        // Load the contents of the PDF into a PdfReader object
        var pdfReader = new PdfReader(pdfStream);

        // Loop over each page of the PDF
        for (int i = 1; i < pdfReader.NumberOfPages; i++)
        {
            // Extract the text from the current page
            var pdfContents = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(pdfReader, i);

            // Split the text into lines
            var pdfLines = pdfContents.Split('\n');

            // Loop through each line of text
            foreach (var line in pdfLines.Skip(4))
            {
                var match = Regex.Match(line, AllowanceScrapping.ALLOWANCE_INFOS_PATTERN);

                if (match.Groups.Count < AllowanceScrapping.ALLOWANCE_INFOS_PATTERN_GROUP_COUNT) continue;

                var country = match.Groups[1].Value;
                var countryCode = match.Groups[2].Value;

                decimal fixedAllowance, geographicAllowance;

                if (!decimal.TryParse(match.Groups[3].Value.FormatValue(), out fixedAllowance)) continue;

                if (!decimal.TryParse(match.Groups[4].Value.FormatValue(), out geographicAllowance)) continue;

                string currencyCode = string.Empty;

                if (!Datas.CountriesCurrencyCode.TryGetValue(country, out currencyCode)) continue;

                allowances.Add(new Allowance()
                {
                    Country = country,
                    CountryCode = countryCode,
                    FixedAllowance = fixedAllowance,
                    GeographicAllowance = geographicAllowance,
                    CurrencyCode = currencyCode,
                });
            }
        }
        pdfStream.Close();

        return allowances;
    }
}