namespace Hermes.Frameworks.DDD.Exceptions;

public class DomainException : Exception
{
    public DomainException(
        string code,
        Exception? innerException = default,
        params (string Key, object Value)[] parameters) : base(code, innerException)
    {
        foreach (var parameter in parameters)
            Data.Add(parameter.Key, parameter.Value);
    }

    public DomainException(string code, params (string Key, object Value)[] parameters)
        : this(code, default, parameters)
    {
    }
}