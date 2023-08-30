namespace Fintech;

public interface IExpression
{
    Money Reduce(ExchangeRates exchangeRates, Currency to);
}