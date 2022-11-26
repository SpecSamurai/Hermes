using Hermes.Catalog.API.Events.Models;

namespace Hermes.Catalog.API.Events;

public class OrderStockRejectedEvent : IEvent
{
    public Guid OrderId { get; init; }
    public List<ValidatedOrderStockItem> OrderStockItems { get; init; } = new();
}