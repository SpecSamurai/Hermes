namespace Hermes.Frameworks.Functional.Fintech;

public class InvalidCurrencyOperationException : InvalidOperationException
{
    public InvalidCurrencyOperationException(string message) : base(message)
    {
    }

    public InvalidCurrencyOperationException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public InvalidCurrencyOperationException(params string[] currencyCodes)
        : base($"Failed to perform the operation with the specified currencies:{string.Join(',', currencyCodes)}")
    {
    }
}