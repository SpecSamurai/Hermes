namespace Hermes.Frameworks.Functional.Results;

public static class Result
{
    public static IResult<TValue> Success<TValue>(TValue success) =>
        new Success<TValue>(success);

    public static IResult<TValue> Failure<TValue>(ErrorMessage failure) =>
        new Failure<TValue>(failure);

    public static IResult<TValue> Failure<TValue>(string code, params (string Key, object Value)[] parameters) =>
        new Failure<TValue>(
            new ErrorMessage(code, parameters));
}