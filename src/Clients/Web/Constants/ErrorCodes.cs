namespace Hermes.Client.Web.Constants;

internal static class ErrorCodes
{
    public const string InvalidStatusCode = $"{nameof(ErrorCodes)}|{nameof(InvalidStatusCode)}";

    internal static class Catalog
    {
        public const string GetPageFailed = $"{nameof(Catalog)}|{nameof(GetPageFailed)}";
    }
}