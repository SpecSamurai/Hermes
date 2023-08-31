namespace Fintech;

public partial record Money
{
    public static bool operator >(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount > right.Amount
            : throw new MoneyException(
                Errors.InvalidCurrenciesError,
                (nameof(left.Currency), left.Currency),
                (nameof(right.Currency), right.Currency));

    public static bool operator <(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount < right.Amount
            : throw new MoneyException(
                Errors.InvalidCurrenciesError,
                (nameof(left.Currency), left.Currency),
                (nameof(right.Currency), right.Currency));

    public static bool operator >=(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount >= right.Amount
            : throw new MoneyException(
                Errors.InvalidCurrenciesError,
                (nameof(left.Currency), left.Currency),
                (nameof(right.Currency), right.Currency));

    public static bool operator <=(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount <= right.Amount
            : throw new MoneyException(
                Errors.InvalidCurrenciesError,
                (nameof(left.Currency), left.Currency),
                (nameof(right.Currency), right.Currency));
}