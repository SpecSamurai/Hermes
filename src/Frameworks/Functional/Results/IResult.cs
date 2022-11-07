namespace Hermes.Frameworks.Functional.Results;

public interface IResult<TValue>
{
    TOutput Match<TOutput>(Func<TValue, TOutput> onSuccess, Func<string, TOutput> onFailure);
}