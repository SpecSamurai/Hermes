namespace Hermes.Frameworks.DDD.Events;

public abstract record DomainEvent
{
    public DateTime Timestamp { get; init; } = DateTime.UtcNow;
}