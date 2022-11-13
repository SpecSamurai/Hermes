namespace Hermes.Frameworks.Repositories.ReadOnly;

public interface IQueryByIdRepository<TEntity, TKey>
{
    Task<TEntity> GetAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default);
    Task<TEntity?> FindAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default);
}