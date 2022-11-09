namespace Hermes.Frameworks.Functional.Results;

public static class ResultMonadExtensions
{
    public static IResult<TResult> Bind<TValue, TResult>(
        this IResult<TValue> result,
        Func<TValue, IResult<TResult>> mapping) =>
            result.Map(mapping).Flatten();

    public static async Task<IResult<TResult>> BindAsync<TValue, TResult>(
        this IResult<TValue> result,
        Func<TValue, Task<IResult<TResult>>> mapper) =>
            (await result.MapAsync(mapper)).Flatten();

    public static IResult<TValue> Flatten<TValue>(this IResult<IResult<TValue>> result) =>
        result.Match(
            onSuccess: success => success,
            onFailure: failure => Result.Failure<TValue>(failure));
}