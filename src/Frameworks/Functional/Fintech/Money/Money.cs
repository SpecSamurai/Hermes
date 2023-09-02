namespace Fintech;

public partial record Money : IExpression
{
    public Money(decimal amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }

    public decimal Amount { get; }
    public Currency Currency { get; }

    public void Deconstruct(out decimal amount, out Currency currency)
    {
        amount = Amount;
        currency = Currency;
    }

    public Money Reduce(ExchangeRates exchangeRates, Currency to)
    {
        var rate = exchangeRates[(Currency, to)];
        return new Money(Amount * rate, to);
    }
}