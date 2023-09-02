namespace Fintech.Serialization;

public sealed class MoneySerializerOptions
{
    static MoneySerializerOptions()
    {
        Default = new()
        {
            Currencies = IsoCurrencies.All,
            Converters = new[]
            {
                new StringToMoneyConverter()
            }
        };
    }

    public static MoneySerializerOptions Default { get; }

    public CurrencyNamingPolicy CurrencyNamingPolicy { internal get; init; }
    public required IReadOnlyDictionary<string, Currency> Currencies { internal get; init; }
    public required IEnumerable<IMoneyConverter> Converters { internal get; init; }
}