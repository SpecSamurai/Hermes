using System.Linq.Expressions;

namespace Hermes.Frameworks.Repositories.DataStructures;

public record Keyset<TEntity>
{
    public required Expression<Func<TEntity, bool>> Predicate { get; init; }
    public required int Take { get; init; }
}