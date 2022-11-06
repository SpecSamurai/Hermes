using System.Linq.Expressions;
using LinqKit;

namespace Hermes.Frameworks.Specifications;

public class OrSpecification<T> : CompositeSpecification<T>
{
    public OrSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right)
    {
    }

    public override Expression<Func<T, bool>> ToExpression() =>
        Left.ToExpression().Or(Right.ToExpression());
}