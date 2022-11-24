using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Newtonsoft.Json.Linq;

namespace BlazorApp.BlazorTools.Data;

public class CosmosDbService
{
    private readonly CosmosClient _cosmosClient;

    public CosmosDbService(CosmosClient cosmosClient)
    {
        _cosmosClient = cosmosClient;
    }

    public async IAsyncEnumerable<GetDatabasesResponse> GetDatabasesAsync()
    {
        using var iterator = _cosmosClient.GetDatabaseQueryIterator<DatabaseProperties>();

        while (iterator.HasMoreResults)
        {
            foreach (var item in await iterator.ReadNextAsync())
            {
                yield return new GetDatabasesResponse
                {
                    DatabaseName = item.Id
                };
            }
        }
    }

    public async IAsyncEnumerable<GetContainersResponse> GetContainersAsync()
    {
        using var dbIterator = _cosmosClient.GetDatabaseQueryIterator<DatabaseProperties>();
        while (dbIterator.HasMoreResults)
        {
            foreach (var database in await dbIterator.ReadNextAsync())
            {
                var containerIterator = _cosmosClient.GetDatabase(database.Id).GetContainerQueryIterator<ContainerProperties>();
                while (containerIterator.HasMoreResults)
                {
                    foreach (var container in await containerIterator.ReadNextAsync())
                    {
                        yield return new GetContainersResponse
                        {
                            DatabaseName = database.Id,
                            ContainerName = container.Id,
                            ContainerId = container.Id,
                            ContainerPartitionKey = container.PartitionKeyPath
                        };
                    }
                }
            }
        }
    }

    public async IAsyncEnumerable<string> GetItemsAsync(string databaseId, string containerId, int skip, int take)
    {
        var iterator = _cosmosClient.GetContainer(databaseId, containerId).GetItemLinqQueryable<JObject>().Skip(skip).Take(take).ToFeedIterator();
        while (iterator.HasMoreResults)
        {
            foreach (var jobject in await iterator.ReadNextAsync())
            {
                yield return jobject.ToString();
            }
        }
    }

    public class GetContainersResponse
    {
        public required string DatabaseName { get; set; }
        public required string ContainerName { get; set; }
        public required string ContainerId { get; set; }
        public required string ContainerPartitionKey { get; set; }
    }

    public class GetDatabasesResponse
    {
        public required string DatabaseName { get; set; }
    }
}