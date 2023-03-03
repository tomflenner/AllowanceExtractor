using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using static AllowanceExtractor.Function.Datas;

namespace AllowanceExtractor.Function;

public static class PdfParsing
{
    public const string ALLOWANCE_INFOS_PATTERN = @"^([A-Z\-'\s(,)]+) (\d{0,3})\s+([\d+,.\s]+ [€])\s+([\d+,.\s]+ [€])\s+([\d+,.\s]+ [€])";
    public const string ALLOWANCES_DATE_PATTERN = @"(?i)1er (janvier|avril|juillet|octobre) \d{4}";
    public const int ALLOWANCE_INFOS_PATTERN_GROUP_COUNT = 6;

    public static async Task<AllowanceDocument> ParsePdf(HttpContent responseContent)
    {
        AllowanceDocument allowanceDocument = new AllowanceDocument();
        var allowances = new List<Allowance>();
        DateTime documentDate;

        using (var pdfStream = await responseContent.ReadAsStreamAsync())
        {
            // Load the contents of the PDF into a PdfReader object
            var pdfReader = new PdfReader(pdfStream);

            // Loop over each page of the PDF
            for (int pageNumber = 1; pageNumber < pdfReader.NumberOfPages; pageNumber++)
            {
                // Extract the text from the current page
                var pdfContents = PdfTextExtractor.GetTextFromPage(pdfReader, pageNumber);

                // Split the text into lines
                var pdfLines = pdfContents.Split('\n');

                // Only for first page
                if (pageNumber == 1)
                {
                    var match = Regex.Match(pdfLines[0], ALLOWANCES_DATE_PATTERN);

                    // Document date found
                    if (match.Success)
                    {
                        var formattedDate = match.Value.ToLower().Replace("1er", "1");

                        CultureInfo cultureInfo = new CultureInfo("fr-FR");

                        // We have a date
                        if (DateTime.TryParseExact(formattedDate, "d MMMM yyyy", cultureInfo, style: System.Globalization.DateTimeStyles.None, out documentDate))
                        {
                            allowanceDocument.DocumentDate = documentDate;
                        }
                    }
                }

                ExtractDatasFromPdfLines(allowances, pdfLines);
            }
        }

        allowanceDocument.Allowances = allowances;

        return allowanceDocument;
    }

    private static void ExtractDatasFromPdfLines(List<Allowance> allowances, string[] pdfLines)
    {
        // Loop through each line of text
        foreach (var line in pdfLines.Skip(4))
        {
            var match = Regex.Match(line, ALLOWANCE_INFOS_PATTERN);

            if (!match.Success) continue;

            if (match.Groups.Count < ALLOWANCE_INFOS_PATTERN_GROUP_COUNT) continue;

            var country = match.Groups[1].Value;
            var countryCode = match.Groups[2].Value;

            decimal fixedAllowance, geographicAllowance;

            if (!decimal.TryParse(match.Groups[3].Value.FormatValue(), out fixedAllowance)) continue;

            if (!decimal.TryParse(match.Groups[4].Value.FormatValue(), out geographicAllowance)) continue;

            CountryInfos countryInfos;

            if (!Datas.CountriesInfos.TryGetValue(int.Parse(countryCode), out countryInfos)) continue;

            allowances.Add(new Allowance()
            {
                CountryName = country,
                CountryCode = countryCode,
                FixedAllowance = fixedAllowance,
                GeographicAllowance = geographicAllowance,
                CountryCurrencyCode = countryInfos.CurrencyCode,
                CountryIcon = countryInfos.Icon,
            });
        }
    }
}