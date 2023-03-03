using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Linq;
using MongoDB.Driver;
using System;

namespace AllowanceExtractor.Function
{
    public static class AllowanceExtractor
    {
        [FunctionName("AllowanceExtractor")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var connectionString = System.Environment.GetEnvironmentVariable("MongoDBAtlasConnectionString", EnvironmentVariableTarget.Process);
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("AllowanceCalculator");
            var collection = database.GetCollection<AllowanceDocument>("Allowances");

            //Database empty YES
            if (collection.EstimatedDocumentCount() == 0)
            {
                log.LogInformation("Database is empty, parse and insert into it");
                return await ParseAndInsertToDatabase(collection);
            }
            //Database empty NO
            else
            {
                //For filter and findOptions see : https://stackoverflow.com/questions/69741657/mongodb-c-sharp-class-with-no-objectid
                var filter = Builders<AllowanceDocument>.Filter.Empty;

                var findOptions = new FindOptions<AllowanceDocument>()
                {
                    Projection = "{ _id : 0 }",
                };

                var result = (await collection.FindAsync(filter, findOptions)).ToList();

                // Problem here, we should only have ONE entry.
                if (result.Count != 1)
                {
                    // Delete all from database
                    await collection.DeleteManyAsync(filter);

                    log.LogInformation("Database is not empty but got too many document, parse and insert into it again");
                    // Parse and insert
                    return await ParseAndInsertToDatabase(collection);
                }
                else
                {
                    var allowanceDocument = result[0];

                    // The current date is over the quarter document date
                    if (DateTime.Now >= allowanceDocument.DocumentDate.AddMonths(3))
                    {
                        // Delete all from database
                        await collection.DeleteManyAsync(filter);

                        log.LogInformation("Database is not empty but document expired (not in quarter), parse and insert into it again");
                        return await ParseAndInsertToDatabase(collection);
                    }

                    log.LogInformation("Database is not empty, retrieve datas from collection");
                    return new OkObjectResult(allowanceDocument.Allowances);
                }
            }
        }

        private static async Task<IActionResult> ParseAndInsertToDatabase(IMongoCollection<AllowanceDocument> collection)
        {
            //Request WEBSITE
            var allowanceDocument = await RetrieveAllowancesFromBusinessFrance();

            if (allowanceDocument.Allowances.Count() > 0)
            {
                //Store in database
                await collection.InsertOneAsync(allowanceDocument);
                return new OkObjectResult(allowanceDocument);
            }
            else
            {
                return new ObjectResult(value: "No allowance data found") { StatusCode = StatusCodes.Status500InternalServerError };
            }
        }

        private static async Task<AllowanceDocument> RetrieveAllowancesFromBusinessFrance()
        {
            var pdfUrl = AllowanceScrapping.ScrapePdfUrl();

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(pdfUrl);

            if (response.IsSuccessStatusCode)
            {
                return await PdfParsing.ParsePdf(response.Content);
            }

            return null;
        }
    }
}