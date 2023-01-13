namespace Hermes.Frameworks.Functional.Fintech;

public partial record Money
{
    public static bool operator >(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount > right.Amount
            : throw new CurrencyException(
                left.Currency.Code.ToString(),
                right.Currency.Code.ToString());

    public static bool operator <(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount < right.Amount
            : throw new CurrencyException(
                left.Currency.Code.ToString(),
                right.Currency.Code.ToString());

    public static bool operator >=(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount >= right.Amount
            : throw new CurrencyException(
                left.Currency.Code.ToString(),
                right.Currency.Code.ToString());

    public static bool operator <=(Money left, Money right) =>
        left.Currency == right.Currency
            ? left.Amount <= right.Amount
            : throw new CurrencyException(
                left.Currency.Code.ToString(),
                right.Currency.Code.ToString());
}