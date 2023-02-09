using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace AllowanceExtractor.Function
{
    public static class AllowanceExtractor
    {
        [FunctionName("AllowanceExtractor")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var client = new MongoClient(System.Environment.GetEnvironmentVariable("MongoDBAtlasConnectionString"));
            var database = client.GetDatabase("AllowanceCalculator");
            var collection = database.GetCollection<Allowance>("Allowances");

            if (collection.EstimatedDocumentCount() == 0)
            {
                //Collection is empty, so we need to request PDF and parse
                var allowances = await RetrieveAllowancesFromBusinessFrance();

                if (allowances.Count() > 0)
                {
                    await collection.InsertManyAsync(allowances);
                    return new OkObjectResult(value: "Allowances found and inserted in database");
                }
                else
                {
                    return new ObjectResult(value: "No allowance data found") { StatusCode = StatusCodes.Status500InternalServerError };
                }
            }
            else
            {
                //Collection is not empty, so we need to request database
                return new OkObjectResult(value: "Database request ok");
            }

        }

        private static async Task<IEnumerable<Allowance>> RetrieveAllowancesFromBusinessFrance()
        {
            var pdfUrl = AllowanceScrapping.ScrapePdfUrl();

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(pdfUrl);

            if (response.IsSuccessStatusCode)
            {
                return await PdfParsing.ParsePdf(response.Content);
            }

            return Enumerable.Empty<Allowance>();
        }
    }


}
