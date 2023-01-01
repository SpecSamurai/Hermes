using Hermes.Frameworks.Functional.Fintech;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Fintech;

public class CurrencyPairTest
{
    private const Currency FromTest = Currency.USD;
    private const Currency ToTest = Currency.EUR;

    [Fact]
    public void Deconstruct_CurrencyPair_ValidTuple()
    {
        // Arrange
        var sut = new CurrencyPair(FromTest, ToTest);

        // Act
        (Currency from, Currency to) = sut;

        // Assert
        Assert.Equal(FromTest, from);
        Assert.Equal(ToTest, to);
    }

    [Fact]
    public void ImplicitCast_CurrencyPair_ValidTuple()
    {
        // Arrange
        var sut = new CurrencyPair(FromTest, ToTest);

        // Act
        (Currency From, Currency To) actual = sut;

        // Assert
        Assert.Equal(FromTest, actual.From);
        Assert.Equal(ToTest, actual.To);
    }

    [Fact]
    public void ImplicitCast_ValidTuple_CurrencyPair()
    {
        // Arrange
        (Currency From, Currency To) sut = (FromTest, ToTest);

        // Act
        CurrencyPair actual = sut;

        // Assert
        Assert.Equal(FromTest, actual.From);
        Assert.Equal(ToTest, actual.To);
    }

    [Fact]
    public void ToString_CurrencyPair_ValidQuotation()
    {
        // Arrange
        var sut = new CurrencyPair(FromTest, ToTest);

        // Act
        var actual = sut.ToString();

        // Assert
        Assert.Equal("USD/EUR", actual);
    }
}