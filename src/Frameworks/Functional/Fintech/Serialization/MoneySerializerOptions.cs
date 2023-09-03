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
    public string? DecimalFormat { internal get; init; }
    public IFormatProvider? DecimalFormatProvider { internal get; init; }

    public required IReadOnlyDictionary<string, Currency> Currencies { get; init; }
    public required IEnumerable<IMoneyConverter> Converters { get; init; }
}