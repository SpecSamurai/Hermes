namespace Hermes.Client.Web.Constants;

internal static class ErrorCodes
{
    public const string InvalidStatusCode = $"{nameof(ErrorCodes)}|{nameof(InvalidStatusCode)}";

    internal static class Catalog
    {
        public const string GetPageFailed = $"{nameof(Catalog)}|{nameof(GetPageFailed)}";
    }

    internal static class Ordering
    {
        public const string GetPageFailed = $"{nameof(Ordering)}|{nameof(GetPageFailed)}";
    }

    internal static class Payment
    {
        public const string GetPageFailed = $"{nameof(Payment)}|{nameof(GetPageFailed)}";
    }
}