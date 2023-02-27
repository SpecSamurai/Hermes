namespace Hermes.Client.Web.Models.Catalog;

internal class CatalogScriptViewModel
{
    public required string BaseAddress { get; init; }
    public required string GetBasketEndpointPath { get; init; }
    public required string Hub { get; init; }
}