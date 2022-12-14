namespace Hermes.Frameworks.Repositories;

public interface ISupportsRollback
{
    Task RollbackAsync(CancellationToken cancellationToken = default);
}