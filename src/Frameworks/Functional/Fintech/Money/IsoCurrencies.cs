namespace Fintech;

public static class IsoCurrencies
{
    public static readonly Currency USD = new(nameof(IsoCurrencyCode.USD), IsoCurrencyCode.USD.ToString("D"), 2, "United States dollar", "$");
    public static readonly Currency EUR = new(nameof(IsoCurrencyCode.EUR), IsoCurrencyCode.EUR.ToString("D"), 2, "Euro", "€");
    public static readonly Currency CHF = new(nameof(IsoCurrencyCode.CHF), IsoCurrencyCode.CHF.ToString("D"), 2, "Swiss franc", "fr.");
    public static readonly Currency GBP = new(nameof(IsoCurrencyCode.GBP), IsoCurrencyCode.GBP.ToString("D"), 2, "Pound sterling", "£");
    public static readonly Currency JPY = new(nameof(IsoCurrencyCode.JPY), IsoCurrencyCode.JPY.ToString("D"), 0, "Japanese yen", "¥");
    public static readonly Currency XTS = new(nameof(IsoCurrencyCode.XTS), IsoCurrencyCode.XTS.ToString("D"), -1, "Code reserved for testing", "TEST");
    public static readonly Currency XXX = new(nameof(IsoCurrencyCode.XXX), IsoCurrencyCode.XXX.ToString("D"), -1, "No currency", "NONE");
}