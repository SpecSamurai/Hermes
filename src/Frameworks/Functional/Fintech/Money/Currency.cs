namespace Fintech;

public partial record Currency
{
    public Currency(
        string alphabeticCode,
        string numericCode,
        int decimalDigits,
        string englishName,
        string symbol)
    {
        AlphabeticCode = alphabeticCode;
        NumericCode = numericCode;
        DecimalDigits = decimalDigits;
        EnglishName = englishName;
        Symbol = symbol;
    }

    public string AlphabeticCode { get; }
    public string NumericCode { get; }
    public int DecimalDigits { get; }
    public string EnglishName { get; }
    public string Symbol { get; }

    public override string ToString() =>
        AlphabeticCode;
}