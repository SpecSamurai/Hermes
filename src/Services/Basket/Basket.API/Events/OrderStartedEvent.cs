namespace Hermes.Basket.API.Events;

public record OrderStartedEvent : IEvent
{
    public required Guid CustomerId { get; init; }
}