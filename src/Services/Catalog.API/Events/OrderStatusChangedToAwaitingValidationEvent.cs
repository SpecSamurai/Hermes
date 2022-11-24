using Hermes.Catalog.API.Events.Models;

namespace Hermes.Catalog.API.Events;

public class OrderStatusChangedToAwaitingValidationEvent : IEvent
{
    public Guid OrderId { get; init; }
    public List<AwaitingValidationOrderStockItem> OrderStockItems { get; init; } = new();
}