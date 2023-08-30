namespace Fintech;

public partial record Money
{
    public static bool operator >(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount > right.Amount
            : throw new MoneyException(
                left.Currency.ToString(),
                right.Currency.ToString());

    public static bool operator <(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount < right.Amount
            : throw new MoneyException(
                left.Currency.ToString(),
                right.Currency.ToString());

    public static bool operator >=(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount >= right.Amount
            : throw new MoneyException(
                left.Currency.ToString(),
                right.Currency.ToString());

    public static bool operator <=(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount <= right.Amount
            : throw new MoneyException(
                left.Currency.ToString(),
                right.Currency.ToString());
}