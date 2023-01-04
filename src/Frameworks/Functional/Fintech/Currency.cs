namespace Hermes.Frameworks.Functional.Fintech;

public partial record Currency
{
    public Currency(CurrencyCode code, int decimalDigits, string englishName, string symbol)
    {
        Code = code;
        DecimalDigits = decimalDigits;
        EnglishName = englishName;
        Symbol = symbol;
    }

    public CurrencyCode Code { get; }
    public int DecimalDigits { get; }
    public string EnglishName { get; }
    public string Symbol { get; }
}