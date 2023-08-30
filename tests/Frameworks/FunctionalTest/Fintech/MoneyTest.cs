using Hermes.Frameworks.Functional.Fintech;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Fintech;

public class MoneyTest
{
    private readonly Currency FromTest = IsoCurrencies.USD;
    private readonly Currency ToTest = IsoCurrencies.EUR;

    [Fact]
    public void Reduce_USD_EUR()
    {
        // Arrange
        var exchangeRates = new ExchangeRates { { (FromTest, ToTest), 1.5m } };
        var sut = new Money(2, FromTest);

        // Act
        var actual = sut.Reduce(exchangeRates, ToTest);

        // Assert
        Assert.Equal(3.0m, actual.Amount);
        Assert.Equal(ToTest, actual.Currency);
    }
}