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
                return new OkObjectResult("PDF request ok");
            }
            else
            {
                return new ObjectResult("Something went wrong") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }
    }
}
