using System.Globalization;

namespace Hermes.Frameworks.Functional.Fintech;

public static class StringExtensions
{
    internal static bool TryParseToDecimal(this string value, out decimal output) =>
        decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out output) ||
        decimal.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out output) ||
        decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out output);
}