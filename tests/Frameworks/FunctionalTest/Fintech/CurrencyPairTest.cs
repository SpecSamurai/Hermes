using Fintech;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Fintech;

public class CurrencyPairTest
{
    private readonly Currency BaseCurrencyTest = IsoCurrencies.USD;
    private readonly Currency QuoteCurrencyTest = IsoCurrencies.EUR;

    [Fact]
    public void Deconstruct_CurrencyPair_ValidTuple()
    {
        // Arrange
        var sut = new CurrencyPair(BaseCurrencyTest, QuoteCurrencyTest);

        // Act
        (Currency from, Currency quoteCurrency) = sut;

        // Assert
        Assert.Equal(BaseCurrencyTest, from);
        Assert.Equal(QuoteCurrencyTest, quoteCurrency);
    }

    [Fact]
    public void ImplicitCast_CurrencyPair_ValidTuple()
    {
        // Arrange
        var sut = new CurrencyPair(BaseCurrencyTest, QuoteCurrencyTest);

        // Act
        (Currency From, Currency quoteCurrency) actual = sut;

        // Assert
        Assert.Equal(BaseCurrencyTest, actual.From);
        Assert.Equal(QuoteCurrencyTest, actual.quoteCurrency);
    }

    [Fact]
    public void ImplicitCast_ValidTuple_CurrencyPair()
    {
        // Arrange
        (Currency BaseCurrency, Currency QuoteCurrency) sut = (BaseCurrencyTest, QuoteCurrencyTest);

        // Act
        CurrencyPair actual = sut;

        // Assert
        Assert.Equal(BaseCurrencyTest, actual.BaseCurrency);
        Assert.Equal(QuoteCurrencyTest, actual.QuoteCurrency);
    }

    [Fact]
    public void ToString_CurrencyPair_ValidQuotation()
    {
        // Arrange
        var sut = new CurrencyPair(BaseCurrencyTest, QuoteCurrencyTest);

        // Act
        var actual = sut.ToString();

        // Assert
        Assert.Equal("USD/EUR", actual);
    }
}