namespace Fintech.Serialization;

public class StringToMoneyConverter : IMoneyConverter<string>
{
    public bool CanConvert<T>() =>
        typeof(T) == typeof(string);

    public string Read(Money value, MoneySerializerOptions moneySerializerOptions)
    {
        var currency = moneySerializerOptions.CurrencyNamingPolicy switch
        {
            CurrencyNamingPolicy.AlphabeticCode => value.Currency.AlphabeticCode,
            CurrencyNamingPolicy.EnglishName => value.Currency.EnglishName,
            CurrencyNamingPolicy.Symbol => value.Currency.Symbol,
            _ => throw new ArgumentException(
                "Invalid enum value for currency naming policy.", nameof(moneySerializerOptions.CurrencyNamingPolicy)),
        };

        return $"{value.Amount} {currency}";
    }

    public Money? Write(string value, MoneySerializerOptions moneySerializerOptions)
    {
        var currencyCode = new string(value.Where(char.IsLetter).ToArray());
        var amount = value.Replace(currencyCode, string.Empty);

        return amount.TryParseToDecimal(out var decimalAmount) &&
            moneySerializerOptions.Currencies.TryGetValue(currencyCode, out var currency)
            ? decimalAmount.ToMoney(currency)
            : default;
    }
}