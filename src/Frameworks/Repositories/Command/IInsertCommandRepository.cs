namespace Hermes.Frameworks.Repositories.Command;

public interface IInsertCommandRepository<TEntity> : ICommandRepository
{
    Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
    Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);
}