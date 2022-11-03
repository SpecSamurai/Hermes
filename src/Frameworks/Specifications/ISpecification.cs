using System.Linq.Expressions;

namespace Hermes.Frameworks.Specifications;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T @object);
    Expression<Func<T, bool>> ToExpression();
}