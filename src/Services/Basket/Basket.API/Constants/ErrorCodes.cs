namespace Hermes.Basket.API.Constants;

internal static class ErrorCodes
{
    internal static class Redis
    {
        public const string InvalidConnectionString = $"{nameof(Redis)}:{nameof(InvalidConnectionString)}";
    }
}