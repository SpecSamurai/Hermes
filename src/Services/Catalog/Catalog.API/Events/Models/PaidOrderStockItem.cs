namespace Hermes.Catalog.API.Events.Models;

public class PaidOrderStockItem
{
    public Guid ItemId { get; init; }
    public int Units { get; init; }
}