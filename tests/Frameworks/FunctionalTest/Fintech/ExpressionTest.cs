using Fintech;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Fintech;

public class ExpressionTest
{
    private static readonly ExchangeRates exchangeRates = new() {
        { (IsoCurrencies.USD, IsoCurrencies.GBP), 0.8m },
        { (IsoCurrencies.EUR, IsoCurrencies.GBP), 1.2m }
    };

    [Fact]
    public void Reduce_AddExpressions_Sum()
    {
        // Arrange
        var usd = new Money(1, IsoCurrencies.USD);
        var eur = new Money(2, IsoCurrencies.EUR);
        var sut = usd.Add(eur);

        // Act
        var actual = sut.Reduce(exchangeRates, IsoCurrencies.GBP);

        // Assert
        Assert.Equal(3.2m, actual.Amount);
        Assert.Equal(IsoCurrencies.GBP, actual.Currency);
    }

    [Fact]
    public void Reduce_SubtractExpressions_Difference()
    {
        // Arrange
        var usd = new Money(1, IsoCurrencies.USD);
        var eur = new Money(2, IsoCurrencies.EUR);
        var sut = usd.Subtract(eur);

        // Act
        var actual = sut.Reduce(exchangeRates, IsoCurrencies.GBP);

        // Assert
        Assert.Equal(-1.6m, actual.Amount);
        Assert.Equal(IsoCurrencies.GBP, actual.Currency);
    }

    [Fact]
    public void Reduce_MultiplyExpressions_Product()
    {
        // Arrange
        var usd = new Money(1, IsoCurrencies.USD);
        var eur = new Money(2, IsoCurrencies.EUR);
        var sut = usd.Multiply(eur);

        // Act
        var actual = sut.Reduce(exchangeRates, IsoCurrencies.GBP);

        // Assert
        Assert.Equal(1.92m, actual.Amount);
        Assert.Equal(IsoCurrencies.GBP, actual.Currency);
    }

    [Fact]
    public void Reduce_DivideExpressions_Fraction()
    {
        // Arrange
        var usd = new Money(1, IsoCurrencies.USD);
        var eur = new Money(2, IsoCurrencies.EUR);
        var sut = usd.Divide(eur);

        // Act
        var actual = sut.Reduce(exchangeRates, IsoCurrencies.GBP);

        // Assert
        Assert.Equal(0.3333m, actual.Amount, precision: 4);
        Assert.Equal(IsoCurrencies.GBP, actual.Currency);
    }
}