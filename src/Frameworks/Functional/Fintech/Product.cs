namespace Hermes.Frameworks.Functional.Fintech;

public record Product : IComposableExpression
{
    public Product(IExpression left, IExpression right)
    {
        Left = left;
        Right = right;
    }

    public IExpression Left { get; }
    public IExpression Right { get; }

    public Money Reduce(ExchangeRates exchangeRates, Currency to) =>
        Left.Reduce(exchangeRates, to) * Right.Reduce(exchangeRates, to);
}