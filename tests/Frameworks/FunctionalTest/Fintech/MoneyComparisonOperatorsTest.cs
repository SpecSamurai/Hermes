using Hermes.Frameworks.Functional.Fintech;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Fintech;

public class MoneyComparisonOperatorsTest
{
    [Fact]
    public void EqualityOperator_DifferentCurrencies_False()
    {
        // Arrange
        var sut1 = new Money(decimal.Zero, Currency.USD);
        var sut2 = new Money(decimal.Zero, Currency.EUR);

        // Act
        var actual = sut1 == sut2;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void InequalityOperator_DifferentCurrencies_True()
    {
        // Arrange
        var sut1 = new Money(decimal.Zero, Currency.USD);
        var sut2 = new Money(decimal.Zero, Currency.EUR);

        // Act
        var actual = sut1 != sut2;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void LessThanOperator_DifferentCurrencies_ThrowCurrencyException()
    {
        // Arrange & Act
        var sut1 = new Money(decimal.Zero, Currency.USD);
        var sut2 = new Money(decimal.Zero, Currency.EUR);
        Action action = () => _ = sut1 < sut2;

        // Assert
        Assert.Throws<InvalidCurrencyOperationException>(action);
    }

    [Fact]
    public void GreaterThanOperator_DifferentCurrencies_ThrowCurrencyException()
    {
        // Arrange & Act
        var sut1 = new Money(decimal.Zero, Currency.USD);
        var sut2 = new Money(decimal.Zero, Currency.EUR);
        Action action = () => _ = sut1 > sut2;

        // Assert
        Assert.Throws<InvalidCurrencyOperationException>(action);
    }

    [Fact]
    public void LessThanOrEqualOperator_DifferentCurrencies_ThrowCurrencyException()
    {
        // Arrange & Act
        var sut1 = new Money(decimal.Zero, Currency.USD);
        var sut2 = new Money(decimal.Zero, Currency.EUR);
        Action action = () => _ = sut1 <= sut2;

        // Assert
        Assert.Throws<InvalidCurrencyOperationException>(action);
    }

    [Fact]
    public void GreaterThanOrEqualOperator_DifferentCurrencies_ThrowCurrencyException()
    {
        // Arrange & Act
        var sut1 = new Money(decimal.Zero, Currency.USD);
        var sut2 = new Money(decimal.Zero, Currency.EUR);
        Action action = () => _ = sut1 >= sut2;

        // Assert
        Assert.Throws<InvalidCurrencyOperationException>(action);
    }

    [Fact]
    public void EqualityOperator_Same_True()
    {
        // Arrange 
        var sut1 = new Money(decimal.Zero, Currency.XTS);
        var sut2 = new Money(decimal.Zero, Currency.XTS);

        // Act
        var actual = sut1 == sut2;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void EqualityOperator_Different_False()
    {
        // Arrange 
        var sut1 = new Money(1, Currency.XTS);
        var sut2 = new Money(2, Currency.XTS);

        // Act
        var actual = sut1 == sut2;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void InequalityOperator_Same_False()
    {
        // Arrange 
        var sut1 = new Money(decimal.Zero, Currency.XTS);
        var sut2 = new Money(decimal.Zero, Currency.XTS);

        // Act
        var actual = sut1 != sut2;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void InequalityOperator_Different_True()
    {
        // Arrange 
        var sut1 = new Money(1, Currency.XTS);
        var sut2 = new Money(2, Currency.XTS);

        // Act
        var actual = sut1 != sut2;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void LessThanOperator_Same_False()
    {
        // Arrange 
        var sut1 = new Money(decimal.Zero, Currency.XTS);
        var sut2 = new Money(decimal.Zero, Currency.XTS);

        // Act
        var actual = sut1 < sut2;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void LessThanOperator_LeftSmaller_True()
    {
        // Arrange 
        var sut1 = new Money(1, Currency.XTS);
        var sut2 = new Money(2, Currency.XTS);

        // Act
        var actual = sut1 < sut2;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void GreaterThanOperator_Same_False()
    {
        // Arrange 
        var sut1 = new Money(decimal.Zero, Currency.XTS);
        var sut2 = new Money(decimal.Zero, Currency.XTS);

        // Act
        var actual = sut1 > sut2;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void GreaterThanOperator_LeftGreather_True()
    {
        // Arrange 
        var sut1 = new Money(2, Currency.XTS);
        var sut2 = new Money(1, Currency.XTS);

        // Act
        var actual = sut1 > sut2;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void LessThanOrEqualOperator_LeftGreater_False()
    {
        // Arrange 
        var sut1 = new Money(2, Currency.XTS);
        var sut2 = new Money(1, Currency.XTS);

        // Act
        var actual = sut1 <= sut2;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void LessThanOrEqualOperator_Same_True()
    {
        // Arrange 
        var sut1 = new Money(decimal.Zero, Currency.XTS);
        var sut2 = new Money(decimal.Zero, Currency.XTS);

        // Act
        var actual = sut1 <= sut2;

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void GreaterThanOrEqualOperator_LeftSmaller_False()
    {
        // Arrange 
        var sut1 = new Money(1, Currency.XTS);
        var sut2 = new Money(2, Currency.XTS);

        // Act
        var actual = sut1 >= sut2;

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void GreaterThanOrEqualOperator_Same_True()
    {
        // Arrange 
        var sut1 = new Money(decimal.Zero, Currency.XTS);
        var sut2 = new Money(decimal.Zero, Currency.XTS);

        // Act
        var actual = sut1 >= sut2;

        // Assert
        Assert.True(actual);
    }
}