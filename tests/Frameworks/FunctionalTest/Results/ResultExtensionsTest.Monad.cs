using Xunit;

namespace Hermes.Frameworks.Functional.Results;

public partial class ResultExtensionsTest
{
    private const string TestValue = "Success";
    private const string TestError = "Error";

    [Fact]
    public void Bind_Success_Success()
    {
        // Arrange
        var sut = Result.Success(TestValue);

        // Act
        var actual = sut
            .Bind(value => Result.Success(value))
            .Match(
                onSuccess: success => success,
                onFailure: failure => failure
            );

        // Assert
        Assert.Equal(TestValue, actual);
    }

    [Fact]
    public void Bind_SuccessAndFailure_Failure()
    {
        // Arrange
        var sut = Result.Success(TestValue);

        // Act
        var actual = sut
            .Bind(value => Result.Failure<string>(TestError))
            .Match(
                onSuccess: success => success,
                onFailure: failure => failure
            );

        // Assert
        Assert.Equal(TestError, actual);
    }

    [Fact]
    public void Bind_Failure_Failure()
    {
        // Arrange
        var sut = Result.Failure<string>(TestError);

        // Act
        var actual = sut
            .Bind(value => Result.Failure<string>(string.Empty))
            .Match(
                onSuccess: success => success,
                onFailure: failure => failure
            );

        // Assert
        Assert.Equal(TestError, actual);
    }

    [Fact]
    public void Bind_FailureAndSuccess_Failure()
    {
        // Arrange
        var sut = Result.Failure<string>(TestError);

        // Act
        var actual = sut
            .Bind(value => Result.Success(TestValue))
            .Match(
                onSuccess: success => success,
                onFailure: failure => failure
            );

        // Assert
        Assert.Equal(TestError, actual);
    }

    [Fact]
    public void BindAdvanced_Failure_Failure()
    {
        // Arrange
        var sut = Result.Success<string>(TestValue);

        // Act
        var actual = sut
            .Bind(value => Result.Success("value1"))
            .Bind(value => Result.Success("value2"))
            .Bind(value => Result.Failure<string>(TestError))
            .Bind(value => Result.Success("value3"))
            .Match(
                onSuccess: success => success,
                onFailure: failure => failure
            );

        // Assert
        Assert.Equal(TestError, actual);
    }

    [Fact]
    public async Task BindAsync_Success_Success()
    {
        // Arrange
        var sut = Result.Success(TestValue);

        // Act
        var result = await sut.BindAsync<string, string>(async value => await Task.FromResult(Result.Success(value)));
        var actual = result.Match(
            onSuccess: success => success,
            onFailure: failure => failure
        );

        // Assert
        Assert.Equal(TestValue, actual);
    }

    [Fact]
    public async Task BindAsync_SuccessAndFailure_Failure()
    {
        // Arrange
        var sut = Result.Success(TestValue);

        // Act
        var result = await sut.BindAsync<string, string>(async value => await Task.FromResult(Result.Failure<string>(TestError)));
        var actual = result.Match(
            onSuccess: success => success,
            onFailure: failure => failure
        );
        // Assert
        Assert.Equal(TestError, actual);
    }

    [Fact]
    public async Task BindAsync_Failure_Failure()
    {
        // Arrange
        var sut = Result.Failure<string>(TestError);

        // Act
        var result = await sut.BindAsync<string, string>(async value => await Task.FromResult(Result.Failure<string>(string.Empty)));
        var actual = result.Match(
            onSuccess: success => success,
            onFailure: failure => failure
        );

        // Assert
        Assert.Equal(TestError, actual);
    }

    [Fact]
    public async Task BindAsync_FailureAndSuccess_Failure()
    {
        // Arrange
        var sut = Result.Failure<string>(TestError);

        // Act
        var result = await sut.BindAsync<string, string>(async value => await Task.FromResult(Result.Success(TestValue)));
        var actual = result.Match(
            onSuccess: success => success,
            onFailure: failure => failure
        );

        // Assert
        Assert.Equal(TestError, actual);
    }
}