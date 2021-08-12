# moar-serverless-demo
Demo app for Moar Serverless conf 2021

Welcome to the code I used for the Azure Functions Crash Course at the Moar Serverless Conference. 

You can find the slide [here](assets/moar.pdf). The slides contain links to more info and learning modules.

The static site and javascript code is in the frontend folder.
The Azure Function is in the function folder. 

## Instructions to run locally

1. Create a Cosmos DB database and collection. To follow the same format as mine, name the account moarserverlesscosmosdb, the database moarserverless, and the collection counter. You can always use whatever names you'd like.
2. Insert an item into your collection
    ```json
    {
        "id": "1",
        "count": 1,
    }
    ``` 
1. Download Visual Studio Code, Azure Functions Core Tools, and extensions. Instructions [here](https://docs.microsoft.com/azure/azure-functions/functions-develop-local) 
1. Add the [CosmosDB package](https://www.nuget.org/packages/Microsoft.Azure.Functions.Worker.Extensions.CosmosDB/) to your function.
2. Add a local.settings.json file with your Cosmos DB connection string, database name, and collection name. 
    ```json
        "CosmosDBConnectionString":"",
        "DatabaseName":"moarserverless",
        "CollectionName":"counter",
    ``` 
3. Add a "host" entry in your local.settings.json file to enable CORS.
    ```json
        "Host":
        {
            "LocalHttpPort":"7071",
            "CORS":"*"
        }
    ```

## Useful links

- [An overview of Azure Serverless](https://youtu.be/maH1Vn27w60)
- [Create an Azure Cosmos Account](https://docs.microsoft.com/azure/cosmos-db/create-cosmosdb-resources-portal)
- [Azure Functions triggers and bindings](https://docs.microsoft.com/azure/azure-functions/functions-triggers-bindings)
- [Azure Functions Networking Options](https://docs.microsoft.com/azure/azure-functions/security-concepts)
- [Securing Azure Functions](https://docs.microsoft.com/azure/azure-functions/security-concepts)
- [Azure Functions Consumption Plan](https://docs.microsoft.com/azure/azure-functions/consumption-plan)