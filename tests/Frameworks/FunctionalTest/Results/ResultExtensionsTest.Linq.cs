using Xunit;

namespace Hermes.Frameworks.Functional.Results;

public partial class ResultExtensionsTest
{
    private class Stub
    {
        public string? Text { get; set; }
        public int Number { get; set; }
    }

    private Task<IResult<string>> GetSuccess1() =>
        Task.FromResult<IResult<string>>(Result.Success("1"));

    private IResult<string> GetSuccess2() =>
        Result.Success("2");

    private IResult<decimal> GetSuccess3() =>
        Result.Success<decimal>(3m);

    private IResult<string> GetFailure() =>
        Result.Failure<string>(string.Empty);

    [Fact]
    public async Task SelectMany_SuccessesWithAsync_Success()
    {
        // Arrange & Act
        var actual =
            from testValue1 in await GetSuccess1()
            from testValue2 in GetSuccess2()
            from testValue3 in GetSuccess3()
            select new Stub
            {
                Text = testValue1 + testValue2,
                Number = ((int)testValue3)
            };

        var actualValue = actual.Match(
            onSuccess: value => value,
            onFailure: _ => new()
        );

        // Assert
        Assert.IsType<Success<Stub>>(actual);
        Assert.Equal("12", actualValue.Text);
        Assert.Equal(3, actualValue.Number);
    }

    [Fact]
    public async Task SelectMany_FailureWithAsync_Failure()
    {
        // Arrange & Act
        var actual =
            from testValue1 in await GetSuccess1()
            from testValue2 in GetFailure()
            from testValue3 in GetSuccess3()
            select new Stub
            {
                Text = testValue1 + testValue2,
                Number = ((int)testValue3)
            };

        var actualValue = actual.Match(
            onSuccess: value => value,
            onFailure: _ => new()
        );

        // Assert
        Assert.IsType<Failure<Stub>>(actual);
    }

    [Fact]
    public void SelectMany_Success_Success()
    {
        // Arrange
        var test1 = Result.Success(string.Empty);
        var test2 = Result.Success(int.MinValue);

        // Act
        var actual =
            from testValue1 in test1
            from testValue2 in test2
            select testValue1 + testValue2;

        var actualValue = actual.Match(
            onSuccess: value => value,
            onFailure: _ => _
        );

        // Assert
        Assert.IsType<Success<string>>(actual);
    }

    [Fact]
    public void SelectMany_Failures_FirstFailure()
    {
        // Arrange
        var test1 = Result.Failure<string>("Failure1");
        var test2 = Result.Failure<int>("Failure2");

        // Act
        var actual =
            from testValue1 in test1
            from testValue2 in test2
            select testValue1 + testValue2;

        var actualValue = actual.Match(
            onSuccess: value => value,
            onFailure: _ => _
        );

        // Assert
        Assert.IsType<Failure<string>>(actual);
        Assert.Equal("Failure1", actualValue);
    }

    [Fact]
    public void SelectMany_SuccessWithFailure_Failure()
    {
        // Arrange
        var test1 = Result.Success<string>(string.Empty);
        var test2 = Result.Failure<int>("Failure");

        // Act
        var actual =
            from testValue1 in test1
            from testValue2 in test2
            select testValue1 + testValue2;

        var actualValue = actual.Match(
            onSuccess: value => value,
            onFailure: _ => _
        );

        // Assert
        Assert.IsType<Failure<string>>(actual);
        Assert.Equal("Failure", actualValue);
    }
}