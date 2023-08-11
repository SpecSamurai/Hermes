using Hermes.Frameworks.Functional.Results;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Results;

public class FailureTest
{
    private const string TestValue = nameof(FailureTest);

    [Fact]
    public void Constructor_Null_ThrowArgumentNullException()
    {
        // Arrange & Act
        static void sut() => _ = new Failure<string>(null!);

        // Assert
        Assert.Throws<ArgumentNullException>(sut);
    }

    [Fact]
    public void ErrorCode_NotNull_ExpectedCode()
    {
        // Arrange
        var sut = new Failure<string>(new ErrorMessage(TestValue));

        // Act
        var (code, data) = sut.ErrorMessage;

        // Assert
        Assert.Equal(TestValue, code);
        Assert.Empty(data);
    }

    [Fact]
    public void ImplicitCastToErrorMessage_FailureObject_ErrorMessage()
    {
        // Arrange
        var sut = new Failure<string>(new ErrorMessage(TestValue));

        // Act
        ErrorMessage actual = sut;

        // Assert
        // Assert
        Assert.Equal(TestValue, actual.Code);
        Assert.Empty(actual.Data);
    }

    [Fact]
    public void ImplicitCastToFailure_ErrorMessage_Failure()
    {
        // Arrange
        Failure<string> sut = new ErrorMessage(TestValue);

        // Act
        var (code, data) = sut.ErrorMessage;

        // Assert
        Assert.Equal(TestValue, code);
        Assert.Empty(data);
    }

    [Fact]
    public void Match_AlwaysOnFailure()
    {
        // Arrange
        var sut = new Failure<string>(new ErrorMessage(TestValue));

        // Act
        var actual = sut.Match(
            onSuccess: success => string.Empty,
            onFailure: failure => failure.Code
        );

        // Assert
        Assert.Equal(TestValue, actual);
    }

    [Fact]
    public async Task MatchAsync_AlwaysOnFailure()
    {
        // Arrange
        var sut = new Failure<string>(new ErrorMessage(TestValue));

        // Act
        var actual = await sut.MatchAsync(
            onSuccessAsync: async _ => await Task.Run(() => string.Empty),
            onFailure: failure => failure.Code
        );

        // Assert
        Assert.Equal(TestValue, actual);
    }
}