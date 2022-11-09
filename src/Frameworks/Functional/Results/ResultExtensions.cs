namespace Hermes.Frameworks.Functional.Results;

public static class ResultExtensions
{
    public static bool IsSuccess<TValue>(this IResult<TValue> result) =>
        result.Match(
            onSuccess: _ => true,
            onFailure: _ => false
        );

    public static bool IsFailure<TValue>(this IResult<TValue> result) =>
        result.Match(
            onSuccess: _ => false,
            onFailure: _ => true
        );
}