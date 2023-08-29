namespace Hermes.Frameworks.Functional.Fintech;

public record CurrencyPair
{
    public CurrencyPair(Currency baseCurrency, Currency quoteCurrency)
    {
        BaseCurrency = baseCurrency;
        QuoteCurrency = quoteCurrency;
    }

    public Currency BaseCurrency { get; }
    public Currency QuoteCurrency { get; }

    public void Deconstruct(out Currency baseCurrency, out Currency quoteCurrency)
    {
        baseCurrency = BaseCurrency;
        quoteCurrency = QuoteCurrency;
    }

    public override string ToString() =>
        $"{BaseCurrency}/{QuoteCurrency}";

    public static implicit operator (Currency BaseCurrency, Currency QuoteCurrency)(CurrencyPair conversion) =>
        (conversion.BaseCurrency, conversion.QuoteCurrency);

    public static implicit operator CurrencyPair((Currency BaseCurrency, Currency QuoteCurrency) conversion) =>
        new CurrencyPair(conversion.BaseCurrency, conversion.QuoteCurrency);
}