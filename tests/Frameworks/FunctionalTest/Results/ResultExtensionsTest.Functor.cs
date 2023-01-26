using Hermes.Frameworks.Functional.Results;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Results;

public partial class ResultExtensionsTest
{
    private const string TestValue = "Success";
    private const string TestError = "Error";

    [Fact]
    public void Map_Success_Success()
    {
        // Arrange
        var sut = Result.Success(string.Empty);

        // Act
        var actual = sut
            .Map(value => TestValue)
            .Match(
                success => success,
                failure => failure
            );

        // Assert
        Assert.Equal(TestValue, actual);
    }

    [Fact]
    public void Map_Failure_ErrorMessage()
    {
        // Arrange
        var sut = Result.Failure<string>(TestError);

        // Act
        var actual = sut
            .Map(value => TestValue)
            .Match<string>(
                success => success,
                failure => failure
            );

        // Assert
        Assert.Equal(TestError, actual);
    }

    [Fact]
    public async Task MapAsync_Success_Success()
    {
        // Arrange
        var sut = Result.Success(string.Empty);

        // Act
        var result = await sut
            .MapAsync(async value => await Task.Run(() => TestValue));

        var actual = result.Match(
                success => success,
                failure => failure
            );

        // Assert
        Assert.Equal(TestValue, actual);
    }

    [Fact]
    public async Task MapAsync_Failure_ErrorMessage()
    {
        // Arrange
        var sut = Result.Failure<string>(TestError);

        // Act
        var result = await sut.MapAsync(
            async _ => await Task.Run(() => TestValue));

        var actual = result.Match(
            success => success,
            failure => failure);

        // Assert
        Assert.Equal(TestError, actual);
    }
}