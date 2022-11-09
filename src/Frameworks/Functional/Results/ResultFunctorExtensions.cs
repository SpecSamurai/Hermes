namespace Hermes.Frameworks.Functional.Results;

public static class ResultFunctorExtensions
{
    public static IResult<TOutput> Map<TValue, TOutput>(this IResult<TValue> result, Func<TValue, TOutput> mapping) =>
        result.Match(
            onSuccess: success => Result.Success<TOutput>(mapping(success)),
            onFailure: failure => Result.Failure<TOutput>(failure));

    public static async Task<IResult<TOutput>> MapAsync<TValue, TOutput>(this IResult<TValue> result, Func<TValue, Task<TOutput>> mapping) =>
        await result.MatchAsync(
            onSuccess: async success => Result.Success<TOutput>(await mapping(success)),
            onFailure: failure => Result.Failure<TOutput>(failure));
}