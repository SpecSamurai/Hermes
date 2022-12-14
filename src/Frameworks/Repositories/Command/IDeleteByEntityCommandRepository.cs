namespace Hermes.Frameworks.Repositories.Command;

public interface IDeleteByEntityCommandRepository<TEntity>
{
    Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
    Task DeleteManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);
}