namespace Hermes.Frameworks.Functional.Fintech;

public static class ExpressionExtensions
{
    public static IExpression Plus(this IExpression augend, IExpression addend) =>
        new Sum(augend, addend);
}