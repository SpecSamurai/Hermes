namespace Hermes.Catalog.API.Constants;

public static class ApiSettings
{
    public static readonly string ApiTitle = typeof(ApiSettings).Assembly.GetName().Name ?? string.Empty;
    public const string ApiPrefix = "api";
    public const string ApiVersion1 = "v1";
    public const string ApiVersion2 = "v2";

    public const string ItemsEndpoint = "items";
    public const string BrandsEndpoint = "brands";
    public const string ItemTypesEndpoint = "itemtypes";
}