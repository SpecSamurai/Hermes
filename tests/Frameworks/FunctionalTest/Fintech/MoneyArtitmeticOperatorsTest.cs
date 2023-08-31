using Fintech;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Fintech;

public class MoneyArtitmeticOperatorsTest
{
    [Fact]
    public void AdditionOperator_DifferentCurrencies_ThrowCurrencyException()
    {
        // Arrange & Act
        var sut1 = new Money(1, IsoCurrencies.USD);
        var sut2 = new Money(1, IsoCurrencies.EUR);
        var action = () => sut1 + sut2;

        // Assert
        Assert.Throws<MoneyException>(action);
    }

    [Fact]
    public void SubtractionOperator_DifferentCurrencies_ThrowCurrencyException()
    {
        // Arrange & Act
        var sut1 = new Money(1, IsoCurrencies.USD);
        var sut2 = new Money(1, IsoCurrencies.EUR);
        var action = () => sut1 - sut2;

        // Assert
        Assert.Throws<MoneyException>(action);
    }

    [Fact]
    public void MultiplicationOperator_DifferentCurrencies_ThrowCurrencyException()
    {
        // Arrange & Act
        var sut1 = new Money(1, IsoCurrencies.USD);
        var sut2 = new Money(1, IsoCurrencies.EUR);
        var action = () => sut1 * sut2;

        // Assert
        Assert.Throws<MoneyException>(action);
    }

    [Fact]
    public void DivisionOperator_DifferentCurrencies_ThrowCurrencyException()
    {
        // Arrange & Act
        var sut1 = new Money(1, IsoCurrencies.USD);
        var sut2 = new Money(1, IsoCurrencies.EUR);
        var action = () => sut1 / sut2;

        // Assert
        Assert.Throws<MoneyException>(action);
    }

    [Fact]
    public void UnaryMinusOperator_Money_Negation()
    {
        // Arrange
        var sut = new Money(1, IsoCurrencies.XTS);

        // Act
        var actual = -sut;

        // Assert
        Assert.Equal(-1, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }

    [Fact]
    public void AdditionOperator_TheSameCurrencies_Sum()
    {
        // Arrange
        var sut1 = new Money(1, IsoCurrencies.XTS);
        var sut2 = new Money(2, IsoCurrencies.XTS);

        // Act
        var actual = sut1 + sut2;

        // Assert
        Assert.Equal(3, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }

    [Fact]
    public void AdditionOperator_WithLeftDecimal_Sum()
    {
        // Arrange
        var sut1 = 1m;
        var sut2 = new Money(2, IsoCurrencies.XTS);

        // Act
        var actual = sut1 + sut2;

        // Assert
        Assert.Equal(3, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }

    [Fact]
    public void AdditionOperator_WithRightDecimal_Sum()
    {
        // Arrange
        var sut1 = new Money(1, IsoCurrencies.XTS);
        var sut2 = 2m;

        // Act
        var actual = sut1 + sut2;

        // Assert
        Assert.Equal(3, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }

    [Fact]
    public void SubtractionOperator_TheSameCurrencies_Subtracted()
    {
        // Arrange
        var sut1 = new Money(2, IsoCurrencies.XTS);
        var sut2 = new Money(1, IsoCurrencies.XTS);

        // Act
        var actual = sut1 - sut2;

        // Assert
        Assert.Equal(1, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }

    [Fact]
    public void SubtractionOperator_WithLeftDecimal_Subtracted()
    {
        // Arrange
        var sut1 = 2m;
        var sut2 = new Money(1, IsoCurrencies.XTS);

        // Act
        var actual = sut1 - sut2;

        // Assert
        Assert.Equal(1, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }

    [Fact]
    public void SubtractionOperator_WithRightDecimal_Subtracted()
    {
        // Arrange
        var sut1 = new Money(2, IsoCurrencies.XTS);
        var sut2 = 1m;

        // Act
        var actual = sut1 - sut2;

        // Assert
        Assert.Equal(1, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }

    [Fact]
    public void MultiplicationOperator_TheSameCurrencies_Multiplied()
    {
        // Arrange
        var sut1 = new Money(2, IsoCurrencies.XTS);
        var sut2 = new Money(2, IsoCurrencies.XTS);

        // Act
        var actual = sut1 * sut2;

        // Assert
        Assert.Equal(4, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }

    [Fact]
    public void MultiplicationOperator_WithLeftDecimal_Multiplied()
    {
        // Arrange
        var sut1 = 2m;
        var sut2 = new Money(2, IsoCurrencies.XTS);

        // Act
        var actual = sut1 * sut2;

        // Assert
        Assert.Equal(4, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }

    [Fact]
    public void MultiplicationOperator_WithRightDecimal_Multiplied()
    {
        // Arrange
        var sut1 = new Money(2, IsoCurrencies.XTS);
        var sut2 = 2m;

        // Act
        var actual = sut1 * sut2;

        // Assert
        Assert.Equal(4, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }

    [Fact]
    public void DivisionOperator_TheSameCurrencies_Divided()
    {
        // Arrange
        var sut1 = new Money(1, IsoCurrencies.XTS);
        var sut2 = new Money(2, IsoCurrencies.XTS);

        // Act
        var actual = sut1 / sut2;

        // Assert
        Assert.Equal(0.5m, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }

    [Fact]
    public void DivisionOperator_WithLeftDecimal_Divided()
    {
        // Arrange
        var sut1 = 1m;
        var sut2 = new Money(2, IsoCurrencies.XTS);

        // Act
        var actual = sut1 / sut2;

        // Assert
        Assert.Equal(0.5m, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }

    [Fact]
    public void DivisionOperator_WithRightDecimal_Divided()
    {
        // Arrange
        var sut1 = new Money(1, IsoCurrencies.XTS);
        var sut2 = 2m;

        // Act
        var actual = sut1 / sut2;

        // Assert
        Assert.Equal(0.5m, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }
}