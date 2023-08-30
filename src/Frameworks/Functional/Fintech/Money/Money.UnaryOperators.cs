namespace Fintech;

public partial record Money
{
    public static Money operator -(Money money) =>
        new Money(-money.Amount, money.Currency);
}