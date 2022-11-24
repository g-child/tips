namespace BlazorApp.BlazorTools.Models;

public class CosmosDbItemsViewerMetadata
{
    public required string DatabaseId { get; set; }
    public required string ContainerId { get; set; }

    public Dictionary<string, object> Parameters => new()
    {
        { $"{nameof(DatabaseId)}", DatabaseId },
        { $"{nameof(ContainerId)}", ContainerId }
    };
}
