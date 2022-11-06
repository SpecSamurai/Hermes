using System.Linq.Expressions;
using LinqKit;

namespace Hermes.Frameworks.Specifications;

public class NotSpecification<T> : Specification<T>
{
    private readonly ISpecification<T> _specification;

    public NotSpecification(ISpecification<T> specification) =>
        _specification = specification;

    public override Expression<Func<T, bool>> ToExpression() =>
        _specification.ToExpression().Not();
}