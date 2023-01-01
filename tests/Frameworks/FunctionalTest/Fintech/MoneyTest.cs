using Hermes.Frameworks.Functional.Fintech;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Fintech;

public class MoneyTest
{
    private const Currency FromTest = Currency.USD;
    private const Currency ToTest = Currency.EUR;

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

    [Fact]
    public void OperatorPlus_Money_Sum()
    {
        // Arrange
        var exchangeRates = new ExchangeRates { { (FromTest, ToTest), 1.5m } };
        var sut1 = new Money(1, Currency.USD);
        var sut2 = new Money(2, Currency.EUR);

        // Act
        var actual = (Sum)(sut1 + sut2);

        // Assert
        Assert.Equal(actual.Left, sut1);
        Assert.Equal(actual.Right, sut2);
    }
}