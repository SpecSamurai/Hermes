namespace Hermes.Frameworks.Repositories.Command;

public interface IDeleteByIdCommandRepository<TKey, TEntity>
{
    Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default);
}