namespace Hermes.Frameworks.Functional.Fintech;

public class CurrencyException : InvalidOperationException
{
    public CurrencyException(string message) : base(message)
    {
    }

    public CurrencyException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public CurrencyException(params string[] currencyCodes)
        : base($"Failed to perform the operation with the specified currencies:{string.Join(',', currencyCodes)}")
    {
    }
}