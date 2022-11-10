using System.Linq.Expressions;

namespace Hermes.Frameworks.Repositories.ReadOnly;

public interface IReadOnlyByPredicateRepository<TEntity>
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