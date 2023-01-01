namespace Hermes.Frameworks.Functional.Money;

public interface IExpression
{
    Money Reduce(ExchangeRates exchangeRates, Currency to);
}