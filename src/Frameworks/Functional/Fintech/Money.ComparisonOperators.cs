namespace Hermes.Frameworks.Functional.Fintech;

public partial record Money
{
    public static bool operator >(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount > right.Amount
            : throw new InvalidCurrencyOperationException(
                left.Currency.ToString(),
                right.Currency.ToString());

    public static bool operator <(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount < right.Amount
            : throw new InvalidCurrencyOperationException(
                left.Currency.ToString(),
                right.Currency.ToString());

    public static bool operator >=(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount >= right.Amount
            : throw new InvalidCurrencyOperationException(
                left.Currency.ToString(),
                right.Currency.ToString());

    public static bool operator <=(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount <= right.Amount
            : throw new InvalidCurrencyOperationException(
                left.Currency.ToString(),
                right.Currency.ToString());
}