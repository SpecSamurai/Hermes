using System.Linq.Expressions;

namespace Hermes.Frameworks.Repositories.ReadOnly;

public interface IReadOnlyListRepository<TEntity>
{
    Task<long> GetCountAsync(CancellationToken cancellationToken = default);

    Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default);

    Task<List<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>> predicate,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);

    Task<List<TEntity>> GetPagedListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);
}