namespace Fintech;

public class MoneyException : Exception
{
    public MoneyException(
        string message,
        Exception? innerException = default,
        params (string Key, object Value)[] parameters) : base(message, innerException)
    {
        foreach (var parameter in parameters)
            Data.Add(parameter.Key, parameter.Value);
    }

    public MoneyException(string message, params (string Key, object Value)[] parameters)
        : this(message, default, parameters)
    {
    }
}