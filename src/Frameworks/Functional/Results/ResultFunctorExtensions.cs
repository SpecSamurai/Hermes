namespace Hermes.Frameworks.Functional.Results;

public static class ResultFunctorExtensions
{
    public static IResult<TOutput> Map<TValue, TOutput>(this IResult<TValue> result, Func<TValue, TOutput> mapping) =>
        result.Match(
            onSuccess: success => Result.Success(mapping(success)),
            onFailure: Result.Failure<TOutput>);

    public static async Task<IResult<TOutput>> MapAsync<TValue, TOutput>(
        this IResult<TValue> result,
        Func<TValue, Task<TOutput>> mappingAsync) =>
            await result.MatchAsync(
                onSuccessAsync: async success => Result.Success(await mappingAsync(success)),
                onFailure: Result.Failure<TOutput>);
}