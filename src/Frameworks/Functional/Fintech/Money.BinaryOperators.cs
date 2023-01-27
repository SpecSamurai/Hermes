namespace Hermes.Frameworks.Functional.Fintech;

public partial record Money
{
    public static Money operator +(Money left, Money right) =>
        left.Currency == right.Currency
            ? new Money(left.Amount + right.Amount, left.Currency)
            : throw new CurrencyException(
                left.Currency.Code.ToString(),
                right.Currency.Code.ToString());

    public static Money operator +(Money left, decimal right) =>
        new Money(left.Amount + right, left.Currency);

    public static Money operator +(decimal left, Money right) =>
        new Money(left + right.Amount, right.Currency);

    public static Money operator -(Money left, Money right) =>
        left.Currency == right.Currency
            ? new Money(left.Amount - right.Amount, left.Currency)
            : throw new CurrencyException(
                left.Currency.Code.ToString(),
                right.Currency.Code.ToString());

    public static Money operator -(Money left, decimal right) =>
        new Money(left.Amount - right, left.Currency);

    public static Money operator -(decimal left, Money right) =>
        new Money(left - right.Amount, right.Currency);

    public static Money operator *(Money left, Money right) =>
        left.Currency == right.Currency
            ? new Money(left.Amount * right.Amount, left.Currency)
            : throw new CurrencyException(
                left.Currency.Code.ToString(),
                right.Currency.Code.ToString());

    public static Money operator *(Money left, decimal right) =>
        new Money(left.Amount * right, left.Currency);

    public static Money operator *(decimal left, Money right) =>
        new Money(left * right.Amount, right.Currency);

    public static Money operator /(Money left, Money right) =>
        left.Currency == right.Currency
            ? new Money(left.Amount / right.Amount, left.Currency)
            : throw new CurrencyException(
                left.Currency.Code.ToString(),
                right.Currency.Code.ToString());

    public static Money operator /(Money left, decimal right) =>
        new Money(left.Amount / right, left.Currency);

    public static Money operator /(decimal left, Money right) =>
        new Money(left / right.Amount, right.Currency);
}