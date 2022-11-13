using System.Linq.Expressions;

namespace Hermes.Frameworks.Repositories.ReadOnly;

public interface IQueryByPredicateRepository<TEntity>
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