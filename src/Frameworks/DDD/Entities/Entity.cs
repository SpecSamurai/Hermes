using System.Collections.ObjectModel;
using Hermes.Frameworks.DDD.Events;

namespace Hermes.Frameworks.DDD.Entities;

public abstract class Entity<TIdentity>
{
    private readonly ICollection<DomainEvent> _localEvents;
    private readonly ICollection<DomainEvent> _distributedEvents;

    protected Entity(TIdentity id)
    {
        Id = id;
        _localEvents = new Collection<DomainEvent>();
        _distributedEvents = new Collection<DomainEvent>();
    }

    public TIdentity Id { get; }

    public IEnumerable<DomainEvent> LocalEvents => _localEvents;
    public IEnumerable<DomainEvent> DistributedEvents => _distributedEvents;

    public virtual void ClearLocalEvents() =>
        _localEvents.Clear();

    public virtual void ClearDistributedEvents() =>
        _distributedEvents.Clear();

    protected void AddLocalEvent(DomainEvent @event) =>
        _localEvents.Add(@event);

    protected void AddDistributedEvent(DomainEvent @event) =>
        _distributedEvents.Add(@event);
}