namespace Hermes.Frameworks.Repositories.Command;

public interface IDeleteByIdCommandRepository<TKey, TEntity> : ICommandRepository
{
    Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default);
}