namespace Hermes.Frameworks.DDD.Entities;

public abstract class AggregateRoot<TIdentity> : Entity<TIdentity>
{
    protected AggregateRoot(TIdentity id) : base(id)
    {
    }
}