namespace Hermes.Frameworks.Functional.Money;

public record class CurrencyPair
{
    public CurrencyPair(Currency from, Currency to)
    {
        From = from;
        To = to;
    }

    public Currency From { get; }
    public Currency To { get; }

    public void Deconstruct(out Currency from, out Currency to)
    {
        from = From;
        to = To;
    }

    public override string ToString() =>
        $"{From}/{To}";

    public static implicit operator (Currency From, Currency To)(CurrencyPair conversion) =>
        (conversion.From, conversion.To);

    public static implicit operator CurrencyPair((Currency From, Currency To) conversion) =>
        new CurrencyPair(conversion.From, conversion.To);
}