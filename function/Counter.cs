using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Company.Function
{
    public static class Counter
    {
        [Function("Counter")]
        [CosmosDBOutput("%CosmosDb%", "%CosmosCollIn%", ConnectionStringSetting = "CosmosDBConnection")]
    
        public static async Task<object> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req,
        [CosmosDBInput(
                "%CosmosDb%", "%CosmosCollIn%",
                ConnectionStringSetting = "CosmosDBConnection",
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
