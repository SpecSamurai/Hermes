using Hermes.Catalog.API.Events.Models;

namespace Hermes.Catalog.API.Events;

public class OrderStatusChangedToPaidEvent : IEvent
{
    public Guid OrderId { get; init; }
    public List<PaidOrderStockItem> OrderStockItems { get; init; } = new();
}