namespace Hermes.Frameworks.Functional.Fintech;

public record class Money : IExpression
{
    public Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; }
    public Currency Currency { get; }

    public Money Reduce(ExchangeRates exchangeRates, Currency to)
    {
        var rate = exchangeRates[(Currency, to)];
        return new Money(Amount * rate, to);
    }

    public override string ToString() =>
        $"{Amount} {Currency}";

    public static IExpression operator +(Money left, Money right) =>
        left.Plus(right);
}