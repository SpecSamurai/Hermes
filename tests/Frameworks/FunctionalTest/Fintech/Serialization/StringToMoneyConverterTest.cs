using System.Globalization;
using Fintech;
using Fintech.Serialization;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Fintech.Serialization;

public class StringToMoneyConverterTest
{
    [Fact]
    public void CanConvert_String_True()
    {
        // Arrange
        var sut = new StringToMoneyConverter();

        // Act
        var actual = sut.CanConvert<string>();

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void CanConvert_Object_False()
    {
        // Arrange
        var sut = new StringToMoneyConverter();

        // Act
        var actual = sut.CanConvert<object>();

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void Read_InvalidCurrencyNamingPolicy_ThrowArgumentException()
    {
        // Arrange
        var options = new MoneySerializerOptions
        {
            CurrencyNamingPolicy = (CurrencyNamingPolicy)(-1),
            Converters = Enumerable.Empty<IMoneyConverter>(),
            Currencies = new Dictionary<string, Currency>(),
        };
        var sut = new StringToMoneyConverter();
        var test = new Money(1.1337m, IsoCurrencies.XTS);

        // Act
        var actual = () => sut.Read(test, options);

        // Assert
        Assert.Throws<ArgumentException>(actual);
    }

    [Fact]
    public void Read_DefaultOptions_DeserializedMoney()
    {
        // Arrange
        var test = new Money(1234.56789m, IsoCurrencies.XTS);
        var sut = new StringToMoneyConverter();

        // Act
        var actual = sut.Read(test, MoneySerializerOptions.Default);

        // Assert
        Assert.Equal($"1234.56789 XTS", actual);
    }

    [Fact]
    public void Read_Symbol_DeserializedMoneyWithSymbol()
    {
        // Arrange
        var test = new Money(decimal.MaxValue, IsoCurrencies.XTS);
        var options = new MoneySerializerOptions
        {
            CurrencyNamingPolicy = CurrencyNamingPolicy.Symbol,
            Converters = MoneySerializerOptions.Default.Converters,
            Currencies = MoneySerializerOptions.Default.Currencies,
        };

        var sut = new StringToMoneyConverter();

        // Act
        var actual = sut.Read(test, options);

        // Assert
        Assert.Equal($"{decimal.MaxValue} {IsoCurrencies.XTS.Symbol}", actual);
    }

    [Fact]
    public void Read_EnglishName_DeserializedMoneyWithEnglishName()
    {
        // Arrange
        var test = new Money(decimal.MaxValue, IsoCurrencies.XTS);
        var options = new MoneySerializerOptions
        {
            CurrencyNamingPolicy = CurrencyNamingPolicy.EnglishName,
            Converters = MoneySerializerOptions.Default.Converters,
            Currencies = MoneySerializerOptions.Default.Currencies,
        };

        var sut = new StringToMoneyConverter();

        // Act
        var actual = sut.Read(test, options);

        // Assert
        Assert.Equal($"{decimal.MaxValue} {IsoCurrencies.XTS.EnglishName}", actual);
    }

    [Fact]
    public void Read_CustomDecimalFormat_ValidDecimalFormatting()
    {
        // Arrange
        var currency = new Currency("Test", "Test", -1, "Test", "Test");
        var test = new Money(123456789.123456789m, currency);
        var options = new MoneySerializerOptions
        {
            DecimalFormat = "F3",
            Converters = MoneySerializerOptions.Default.Converters,
            Currencies = MoneySerializerOptions.Default.Currencies,
        };

        var sut = new StringToMoneyConverter();

        // Act
        var actual = sut.Read(test, options);

        // Assert
        Assert.Equal($"123456789.123 Test", actual);
    }

    [Fact]
    public void Read_CustomDecimalFormatProvider_InvariantCulture()
    {
        // Arrange
        var currency = new Currency("Test", "Test", -1, "Test", "Test");
        var test = new Money(1.15m, currency);
        var options = new MoneySerializerOptions
        {
            DecimalFormatProvider = new CultureInfo("pl-PL"),
            Converters = MoneySerializerOptions.Default.Converters,
            Currencies = MoneySerializerOptions.Default.Currencies,
        };

        var sut = new StringToMoneyConverter();

        // Act
        var actual = sut.Read(test, options);

        // Assert
        Assert.Equal($"1,15 Test", actual);
    }

    [Fact]
    public void Write_DefaultOptions_ValidMoney()
    {
        // Arrange
        var sut = new StringToMoneyConverter();

        // Act
        var actual = sut.Write("1.15 XTS", MoneySerializerOptions.Default)!;

        // Assert
        Assert.Equal(1.15m, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }
}