namespace Fintech;

public partial record Money
{
    public static bool operator >(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount > right.Amount
            : throw new MoneyException(
                Errors.InvalidCurrenciesError,
                (nameof(left), left.Currency),
                (nameof(right), right.Currency));

    public static bool operator <(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount < right.Amount
            : throw new MoneyException(
                Errors.InvalidCurrenciesError,
                (nameof(left), left.Currency),
                (nameof(right), right.Currency));

    public static bool operator >=(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount >= right.Amount
            : throw new MoneyException(
                Errors.InvalidCurrenciesError,
                (nameof(left), left.Currency),
                (nameof(right), right.Currency));

    public static bool operator <=(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount <= right.Amount
            : throw new MoneyException(
                Errors.InvalidCurrenciesError,
                (nameof(left), left.Currency),
                (nameof(right), right.Currency));
}