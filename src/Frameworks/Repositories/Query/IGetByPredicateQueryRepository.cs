using System.Linq.Expressions;

namespace Hermes.Frameworks.Repositories.Query;

public interface IGetByPredicateQueryRepository<TEntity>
{
    Task<TEntity?> FindAsync(
        Expression<Func<TEntity, bool>> predicate,
        bool includeDetails = true,
        CancellationToken cancellationToken = default);

    Task<TEntity> GetAsync(
        Expression<Func<TEntity, bool>> predicate,
        bool includeDetails = true,
        CancellationToken cancellationToken = default);
}