using System.Linq.Expressions;

namespace Hermes.Frameworks.Repositories.Query;

public interface IGetByPredicateNullableQueryRepository<TEntity>
{
    Task<TEntity?> FindAsync(
        Expression<Func<TEntity, bool>> predicate,
        bool includeDetails = true,
        CancellationToken cancellationToken = default);
}