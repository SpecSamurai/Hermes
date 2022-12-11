namespace Hermes.Payment.API.Events;

public record OrderPaymentFailedEvent : IEvent
{
    public int OrderId { get; init; }
}