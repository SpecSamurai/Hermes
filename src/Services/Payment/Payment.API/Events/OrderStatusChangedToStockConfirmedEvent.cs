namespace Hermes.Payment.API.Events;

public record OrderStatusChangedToStockConfirmedEvent : IEvent
{
    public int OrderId { get; init; }
}