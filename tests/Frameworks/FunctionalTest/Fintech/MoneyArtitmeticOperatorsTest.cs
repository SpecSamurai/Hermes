using Hermes.Frameworks.Functional.Fintech;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Fintech;

public class MoneyArtitmeticOperatorsTest
{
    [Fact]
    public void AdditionOperator_DifferentCurrencies_ThrowCurrencyException()
    {
        // Arrange & Act
        var sut1 = new Money(1, Currency.USD);
        var sut2 = new Money(1, Currency.EUR);
        var action = () => sut1 + sut2;

        // Assert
        Assert.Throws<CurrencyException>(action);
    }

    [Fact]
    public void SubtractionOperator_DifferentCurrencies_ThrowCurrencyException()
    {
        // Arrange & Act
        var sut1 = new Money(1, Currency.USD);
        var sut2 = new Money(1, Currency.EUR);
        var action = () => sut1 - sut2;

        // Assert
        Assert.Throws<CurrencyException>(action);
    }

    [Fact]
    public void MultiplicationOperator_DifferentCurrencies_ThrowCurrencyException()
    {
        // Arrange & Act
        var sut1 = new Money(1, Currency.USD);
        var sut2 = new Money(1, Currency.EUR);
        var action = () => sut1 * sut2;

        // Assert
        Assert.Throws<CurrencyException>(action);
    }

    [Fact]
    public void DivisionOperator_DifferentCurrencies_ThrowCurrencyException()
    {
        // Arrange & Act
        var sut1 = new Money(1, Currency.USD);
        var sut2 = new Money(1, Currency.EUR);
        var action = () => sut1 / sut2;

        // Assert
        Assert.Throws<CurrencyException>(action);
    }

    [Fact]
    public void UnaryMinusOperator_Money_Negation()
    {
        // Arrange
        var sut = new Money(1, Currency.XTS);

        // Act
        var actual = -sut;

        // Assert
        Assert.Equal(-1, actual.Amount);
        Assert.Equal(Currency.XTS, actual.Currency);
    }

    [Fact]
    public void AdditionOperator_TheSameCurrencies_Sum()
    {
        // Arrange
        var sut1 = new Money(1, Currency.XTS);
        var sut2 = new Money(2, Currency.XTS);

        // Act
        var actual = sut1 + sut2;

        // Assert
        Assert.Equal(3, actual.Amount);
        Assert.Equal(Currency.XTS, actual.Currency);
    }

    [Fact]
    public void SubtractionOperator_TheSameCurrencies_Subtracted()
    {
        // Arrange
        var sut1 = new Money(2, Currency.XTS);
        var sut2 = new Money(1, Currency.XTS);

        // Act
        var actual = sut1 - sut2;

        // Assert
        Assert.Equal(1, actual.Amount);
        Assert.Equal(Currency.XTS, actual.Currency);
    }

    [Fact]
    public void MultiplicationOperator_TheSameCurrencies_Multiplied()
    {
        // Arrange
        var sut1 = new Money(2, Currency.XTS);
        var sut2 = new Money(2, Currency.XTS);

        // Act
        var actual = sut1 * sut2;

        // Assert
        Assert.Equal(4, actual.Amount);
        Assert.Equal(Currency.XTS, actual.Currency);
    }

    [Fact]
    public void DivisionOperator_TheSameCurrencies_Divided()
    {
        // Arrange
        var sut1 = new Money(1, Currency.XTS);
        var sut2 = new Money(2, Currency.XTS);

        // Act
        var actual = sut1 / sut2;

        // Assert
        Assert.Equal(0.5m, actual.Amount);
        Assert.Equal(Currency.XTS, actual.Currency);
    }
}