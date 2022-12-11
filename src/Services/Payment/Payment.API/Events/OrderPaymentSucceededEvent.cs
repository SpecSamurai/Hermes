namespace Hermes.Payment.API.Events;

public record OrderPaymentSucceededEvent : IEvent
{
    public int OrderId { get; init; }
}