namespace Hermes.Frameworks.Repositories.Command;

public interface ICommandRepository
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}