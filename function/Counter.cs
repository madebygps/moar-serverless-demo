using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Company.Function
{
    public static class Counter
    {
        [Function("Counter")]
        [CosmosDBOutput("%DatabaseName%", "%CollectionName%", ConnectionStringSetting = "CosmosDBConnectionString")]
    
        public static object Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
        [CosmosDBInput(
                "%DatabaseName%", "%CollectionName%",
                ConnectionStringSetting = "CosmosDBConnectionString",
                Id = "1",
                PartitionKey = "1")] CounterJson input,

            FunctionContext executionContext)
        {
           var logger = executionContext.GetLogger("InsertTodo");
            logger.LogInformation("C# HTTP trigger function processed a request.");

            input.Count++;

            return input;
        
        }
    }

    public class CounterJson
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
