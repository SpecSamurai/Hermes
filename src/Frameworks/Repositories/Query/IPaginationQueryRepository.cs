using System.Linq.Expressions;
using Hermes.Frameworks.Repositories.DataStructures;

namespace Hermes.Frameworks.Repositories.Query;

public interface IPaginationQueryRepository<TEntity>
{
    Task<IList<TResult>> GetPageAsync<TResult>(
        Offset offset,
        Expression<Func<TEntity, TResult>> selector,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) where TResult : notnull;

    Task<IList<TResult>> GetPageAsync<TResult>(
        Keyset<TEntity> keyset,
        Expression<Func<TEntity, TResult>> selector,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) where TResult : notnull;
}