namespace Hermes.Frameworks.Functional.Fintech;

public record Sum : IComposableExpression
{
    public Sum(IExpression augend, IExpression addend)
    {
        Left = augend;
        Right = addend;
    }

    public IExpression Left { get; }
    public IExpression Right { get; }

    public Money Reduce(ExchangeRates exchangeRates, Currency to)
    {
        var sum = Left.Reduce(exchangeRates, to).Amount + Right.Reduce(exchangeRates, to).Amount;
        return new Money(sum, to);
    }
}