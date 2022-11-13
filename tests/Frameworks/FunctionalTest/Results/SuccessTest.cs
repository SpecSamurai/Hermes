using Hermes.Frameworks.Functional.Results;
using Xunit;

namespace Hermes.Frameworks.FunctionalTest.Results;

public class SuccessTest
{
    private const string TestValue = nameof(SuccessTest);

    [Fact]
    public void Constructor_Null_ThrowArgumentNullException()
    {
        // Arrange & Act
        Action sut = () => new Success<string>(null!);

        // Assert
        Assert.Throws<ArgumentNullException>(sut);
    }

    [Fact]
    public void Value_NotNull_Value()
    {
        // Arrange
        var sut = new Success<string>(TestValue);

        // Act
        var actual = sut.Value;

        // Assert
        Assert.Equal(TestValue, actual);
    }

    [Fact]
    public void ImplicitCastToValue_Success_Value()
    {
        // Arrange
        var sut = new Success<string>(TestValue);

        // Act
        string actual = sut;

        // Assert
        Assert.Equal(TestValue, actual);
    }

    [Fact]
    public void ImplicitCastToSuccess_Value_Success()
    {
        // Arrange
        Success<string> sut = TestValue;

        // Act
        var actual = sut.Value;

        // Assert
        Assert.Equal(TestValue, actual);
    }

    [Fact]
    public void Match_AlwaysOnSuccess()
    {
        // Arrange
        var sut = new Success<string>(TestValue);

        // Act
        var actual = sut.Match(
            onSuccess: success => success,
            onFailure: failure => failure.Code
        );

        // Assert
        Assert.Equal(TestValue, actual);
    }

    [Fact]
    public async Task MatchAsync_AlwaysOnSuccess()
    {
        // Arrange
        var sut = new Success<string>(TestValue);

        // Act
        var actual = await sut.MatchAsync(
            onSuccessAsync: async success => await Task.Run(() => success),
            onFailure: failure => failure.Code
        );

        // Assert
        Assert.Equal(TestValue, actual);
    }
}