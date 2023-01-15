namespace Hermes.Frameworks.Functional.Fintech;

public static class ExpressionExtensions
{
    public static IExpression Add(this IExpression left, IExpression right) =>
        new Sum(left, right);

    public static IExpression Subtract(this IExpression left, IExpression right) =>
        new Difference(left, right);

    public static IExpression Multiply(this IExpression left, IExpression right) =>
        new Product(left, right);

    public static IExpression Divide(this IExpression left, IExpression right) =>
        new Fraction(left, right);
}