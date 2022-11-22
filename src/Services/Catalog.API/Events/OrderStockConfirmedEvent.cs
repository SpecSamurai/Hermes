namespace Hermes.Catalog.API.Events;

public class OrderStockConfirmedEvent : IEvent
{
    public Guid OrderId { get; init; }
}