namespace Hermes.Catalog.API.Events.Models;

public class AwaitingValidationOrderStockItem
{
    public Guid ItemId { get; init; }
    public int Units { get; init; }
}