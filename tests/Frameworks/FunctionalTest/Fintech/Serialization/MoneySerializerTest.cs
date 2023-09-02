using Fintech;
using Fintech.Serialization;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Fintech.Serialization;

public class MoneySerializerTest
{
    [Fact]
    public void Deserialize_NotSupportedType_ThrowsNotSupportedException()
    {
        // Arrange & Act
        var actual = () => MoneySerializer.Deserialize<object>(default!);

        // Assert
        Assert.Throws<NotSupportedException>(actual);
    }

    [Fact]
    public void Serialize_NotSupportedType_ThrowsNotSupportedException()
    {
        // Arrange & Act
        var actual = () => MoneySerializer.Serialize<object>(new());

        // Assert
        Assert.Throws<NotSupportedException>(actual);
    }

    [Fact]
    public void Deserialize_Money_String()
    {
        // Arrange
        var test = new Money(1, IsoCurrencies.XTS);

        // Act
        var actual = MoneySerializer.Deserialize<string>(test);

        // Assert
        Assert.Equal("1 XTS", actual);
    }

    [Fact]
    public void Serialize_String_Money()
    {
        // Arrange & Act
        var actual = MoneySerializer.Serialize("1 XTS")!;

        // Assert
        Assert.Equal(1, actual.Amount);
        Assert.Equal(IsoCurrencies.XTS, actual.Currency);
    }
}