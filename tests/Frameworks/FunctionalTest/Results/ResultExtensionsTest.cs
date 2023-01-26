using Xunit;

namespace Hermes.Frameworks.Functional.Results;

public partial class ResultExtensionsTest
{
    [Fact]
    public void IsSuccess_Success_True()
    {
        // Arrange
        var sut = Result.Success(string.Empty);

        // Act
        var actual = sut.IsSuccess();

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void IsSuccess_Failure_False()
    {
        // Arrange
        var sut = Result.Failure<string>(string.Empty);

        // Act
        var actual = sut.IsSuccess();

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsFailure_Success_False()
    {
        // Arrange
        var sut = Result.Success(string.Empty);

        // Act
        var actual = sut.IsFailure();

        // Assert
        Assert.False(actual);
    }

    [Fact]
    public void IsFailure_Failure_True()
    {
        // Arrange
        var sut = Result.Failure<string>(string.Empty);

        // Act
        var actual = sut.IsFailure();

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void ToSuccess_AnyObject_Success()
    {
        // Arrange
        var testValue = string.Empty;
        var sut = testValue.ToSuccess();

        // Act
        var actual = sut.Value;

        // Assert
        Assert.IsType<Success<string>>(sut);
        Assert.Equal(testValue, actual);
    }

    [Fact]
    public void GetValueOrFallback_Success_Value()
    {
        // Arrange
        var testValue = string.Empty;
        var sut = testValue.ToSuccess();

        // Act
        var actual = sut.GetValueOrFallback("fallback");

        // Assert
        Assert.IsType<Success<string>>(sut);
        Assert.Equal(testValue, actual);
    }

    [Fact]
    public void GetValueOrFallback_Failure_Fallback()
    {
        // Arrange
        var sut = Result.Failure<string>(string.Empty);

        // Act
        var actual = sut.GetValueOrFallback(TestValue);

        // Assert
        Assert.IsType<Failure<string>>(sut);
        Assert.Equal(TestValue, actual);
    }
}