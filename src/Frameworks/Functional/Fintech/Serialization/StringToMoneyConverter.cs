namespace Fintech.Serialization;

public class StringToMoneyConverter : IMoneyConverter<string>
{
    public bool CanConvert<T>() =>
        typeof(T) == typeof(string);

    public string Read(Money value, MoneySerializerOptions moneySerializerOptions)
    {
        var currency = value.Currency.ToString(moneySerializerOptions.CurrencyNamingPolicy);
        var amount = value.Amount.ToString(
            moneySerializerOptions.DecimalFormat,
            moneySerializerOptions.DecimalFormatProvider);

        return $"{amount} {currency}";
    }

    public Money? Write(string value, MoneySerializerOptions moneySerializerOptions)
    {
        var currencyCode = new string(value.Where(char.IsLetter).ToArray());
        var amount = value.Replace(currencyCode, string.Empty);

        return decimal.TryParse(amount, moneySerializerOptions.DecimalFormatProvider, out var decimalAmount) &&
            moneySerializerOptions.Currencies.TryGetValue(currencyCode, out var currency)
            ? decimalAmount.ToMoney(currency)
            : default;
    }
}