using System.Linq.Expressions;

namespace Hermes.Frameworks.Repositories.Query;

public interface IListQueryRepository<TEntity>
{
    Task<List<TResult>> GetListAsync<TResult>(
        Expression<Func<TEntity, bool>> predicate,
        Expression<Func<TEntity, TResult>> selector,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);
}