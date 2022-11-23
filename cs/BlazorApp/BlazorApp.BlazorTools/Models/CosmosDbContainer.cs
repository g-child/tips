namespace BlazorApp.BlazorTools.Models;

public class CosmosDbContainer
{
    public required string Name { get; set; }
    public required string IdName { get; set; }
    public required string PartitionKeyName { get; set; }
}