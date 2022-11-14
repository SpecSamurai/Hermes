using System.Linq.Expressions;

namespace Hermes.Frameworks.Repositories.Command;

public interface IDeleteByPredicateCommandRepository<TEntity> : ICommandRepository
{
    Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default);
}