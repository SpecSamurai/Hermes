namespace Hermes.Basket.API.Constants;

public static class ApiSettings
{
    public static readonly string ApiTitle = typeof(ApiSettings).Assembly.GetName().Name ?? string.Empty;
    public const string ApiPrefix = "api";
    public const string ApiVersion1 = "v1";

    public const string BasketEndpoint = "basket";
}