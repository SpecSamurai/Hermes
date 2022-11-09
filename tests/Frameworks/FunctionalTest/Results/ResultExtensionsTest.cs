using Xunit;

namespace Hermes.Frameworks.Functional.Results;

public class ResultExtensionsTest
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
}