namespace Fintech.Serialization;

internal static class CurrencyExtensions
{
    internal static string ToString(this Currency currency, CurrencyNamingPolicy currencyNamingPolicy) =>
        currencyNamingPolicy switch
        {
            CurrencyNamingPolicy.AlphabeticCode => currency.AlphabeticCode,
            CurrencyNamingPolicy.EnglishName => currency.EnglishName,
            CurrencyNamingPolicy.Symbol => currency.Symbol,
            _ => throw new ArgumentException(
                "Invalid enum value for currency naming policy.", nameof(currencyNamingPolicy)),
        };
}