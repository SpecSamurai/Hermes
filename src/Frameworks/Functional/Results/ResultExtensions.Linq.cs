namespace Hermes.Frameworks.Functional.Results;

public static partial class ResultExtensions
{
    public static IResult<TOutput> SelectMany<TSource, TResult, TOutput>(
        this IResult<TSource> source,
        Func<TSource, IResult<TResult>> resultSelector,
        Func<TSource, TResult, TOutput> outputSelector) =>
            source.Bind(sourceValue =>
                resultSelector(sourceValue).Map(resultValue => outputSelector(sourceValue, resultValue)));
}