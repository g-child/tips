using Microsoft.Azure.Cosmos;

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