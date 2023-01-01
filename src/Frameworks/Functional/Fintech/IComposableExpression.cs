namespace Hermes.Frameworks.Functional.Fintech;

public interface IComposableExpression : IExpression
{
    IExpression Left { get; }
    IExpression Right { get; }
}