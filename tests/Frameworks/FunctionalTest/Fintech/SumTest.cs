using Hermes.Frameworks.Functional.Fintech;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Fintech;

public class SumTest
{
    [Fact]
    public void Reduce_Money_Sum()
    {
        // Arrange
        var exchangeRates = new ExchangeRates {
            { (Currency.USD, Currency.GBP), 0.8m },
            { (Currency.EUR, Currency.GBP), 1.2m },
        };

        var usd = new Money(1, Currency.USD);
        var eur = new Money(2, Currency.EUR);
        var sut = new Sum(usd, eur);

        // Act
        var actual = sut.Reduce(exchangeRates, Currency.GBP);

        // Assert
        Assert.Equal(actual.Amount, 3.2m);
        Assert.Equal(actual.Currency, Currency.GBP);
    }
}