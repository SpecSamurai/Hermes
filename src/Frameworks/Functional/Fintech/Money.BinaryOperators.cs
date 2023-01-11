namespace Hermes.Frameworks.Functional.Fintech;

public partial record Money
{
    public static Money operator +(Money left, Money right) =>
        left.Currency == right.Currency
            ? new Money(left.Amount + right.Amount, left.Currency)
            : throw new CurrencyException(
                left.Currency.Code.ToString(),
                right.Currency.Code.ToString());

    public static Money operator -(Money left, Money right) =>
        left.Currency == right.Currency
            ? new Money(left.Amount - right.Amount, left.Currency)
            : throw new CurrencyException(
                left.Currency.Code.ToString(),
                right.Currency.Code.ToString());

    public static Money operator *(Money left, Money right) =>
        left.Currency == right.Currency
            ? new Money(left.Amount * right.Amount, left.Currency)
            : throw new CurrencyException(
                left.Currency.Code.ToString(),
                right.Currency.Code.ToString());

    public static Money operator /(Money left, Money right) =>
        left.Currency == right.Currency
            ? new Money(left.Amount / right.Amount, left.Currency)
            : throw new CurrencyException(
                left.Currency.Code.ToString(),
                right.Currency.Code.ToString());
}