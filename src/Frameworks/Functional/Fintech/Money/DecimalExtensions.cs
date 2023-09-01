namespace Fintech;

public static class DecimalExtensions
{
    public static Money ToMoney(this decimal amount, Currency currency) =>
        new(amount, currency);
}