using System.Linq.Expressions;

namespace Hermes.Frameworks.Repositories.Query;

public interface IListByIdQueryRepository<TKey, TEntity>
{
    Task<List<TResult>> GetListAsync<TResult>(
        IEnumerable<TKey> ids,
        Expression<Func<TEntity, TResult>> selector,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);
}