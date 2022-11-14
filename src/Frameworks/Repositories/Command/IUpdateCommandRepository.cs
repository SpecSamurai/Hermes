namespace Hermes.Frameworks.Repositories.Command;

public interface IUpdateCommandRepository<TEntity> : ICommandRepository
{
    Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
    Task UpdateManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);
}