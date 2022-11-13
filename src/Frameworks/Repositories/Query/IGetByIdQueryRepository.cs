namespace Hermes.Frameworks.Repositories.Query;

public interface IGetByIdQueryRepository<TKey, TEntity>
{
    Task<TEntity> GetAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default);
    Task<TEntity?> FindAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default);
}