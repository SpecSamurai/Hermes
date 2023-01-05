namespace Hermes.Frameworks.Functional.Fintech;

public partial record Currency
{
    public static readonly Currency USD = new Currency(CurrencyCode.USD, 2, "United States dollar", "$");
    public static readonly Currency EUR = new Currency(CurrencyCode.EUR, 2, "Euro", "€");
    public static readonly Currency CHF = new Currency(CurrencyCode.CHF, 2, "Swiss franc", "fr.");
    public static readonly Currency GBP = new Currency(CurrencyCode.GBP, 2, "Pound sterling", "£");
    public static readonly Currency JPY = new Currency(CurrencyCode.JPY, 0, "Japanese yen", "¥");
    public static readonly Currency XTS = new Currency(CurrencyCode.XTS, -1, "Code reserved for testing", "TEST");
    public static readonly Currency XXX = new Currency(CurrencyCode.XXX, -1, "No currency", "NONE");
}