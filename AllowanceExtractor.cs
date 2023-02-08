using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using HtmlAgilityPack;
using System.Net.Http;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace AllowanceExtractor.Function
{
    public static class AllowanceExtractor
    {
        private const string ALLOWANCE_INFOS_PATTERN = @"^([A-Z\-'\s(,)]+) (\d{0,3})\s+([\d+,.\s]+ [€])\s+([\d+,.\s]+ [€])\s+([\d+,.\s]+ [€])";
        private const string ALLOWANCE_URL = "https://mon-vie-via.businessfrance.fr/indemnite-vie";

        [FunctionName("AllowanceExtractor")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var web = new HtmlWeb();
            var html = web.Load(ALLOWANCE_URL);
            var a = html.DocumentNode.SelectSingleNode("//a[contains(text(), 'Barème V.I.E')]/@href");
            var href = a.GetAttributeValue("href", null);

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(href);

            if (response.IsSuccessStatusCode)
            {
                var pdfStream = await response.Content.ReadAsStreamAsync();

                // Load the contents of the PDF into a PdfReader object
                var pdfReader = new PdfReader(pdfStream);

                // Retrieve allowances info from contents of the PDF
                var allowances = new List<Allowance>();

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
                        var match = Regex.Match(line, ALLOWANCE_INFOS_PATTERN);

                        if (match.Groups.Count < 6) continue;

                        var country = match.Groups[1].Value;
                        var countryCode = match.Groups[2].Value;

                        decimal fixedAllowance, geographicAllowance;

                        if (!decimal.TryParse(match.Groups[3].Value.FormatValue(), out fixedAllowance)) continue;

                        if (!decimal.TryParse(match.Groups[4].Value.FormatValue(), out geographicAllowance)) continue;

                        string currencyCode = string.Empty;

                        if (!Constants.Countries.TryGetValue(country, out currencyCode)) continue;

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

                pdfStream.Close(); return new OkObjectResult("PDF request ok");
            }
            else
            {
                return new ObjectResult("Something went wrong") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }

    public class Allowance
    {
        public string Country { get; set; } = string.Empty;

        public string CountryCode { get; set; } = string.Empty;

        public string CurrencyCode { get; set; } = string.Empty;

        public decimal FixedAllowance { get; set; }

        public decimal GeographicAllowance { get; set; }
    }
}
