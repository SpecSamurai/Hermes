namespace Hermes.Frameworks.Functional.Fintech;

public interface IExpression
{
    Money Reduce(ExchangeRates exchangeRates, Currency to);
}