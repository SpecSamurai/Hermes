namespace Hermes.Catalog.API.Events.Models;

public class ValidatedOrderStockItem
{
    public Guid ItemId { get; init; }
    public bool HasStock { get; init; }
}