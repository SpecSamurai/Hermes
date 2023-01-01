namespace Hermes.Frameworks.Functional.Money;

public interface IComposableExpression : IExpression
{
    IExpression Left { get; }
    IExpression Right { get; }
}