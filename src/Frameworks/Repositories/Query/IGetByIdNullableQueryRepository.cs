namespace Hermes.Frameworks.Repositories.Query;

public interface IGetByIdNullableQueryRepository<TKey, TEntity>
{
    Task<TEntity?> FindAsync(
        TKey id,
        bool includeDetails = true,
        CancellationToken cancellationToken = default);
}