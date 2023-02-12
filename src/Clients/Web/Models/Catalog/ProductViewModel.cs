namespace Hermes.Client.Web.Models.Catalog;

internal class ProductViewModel
{
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
    public required string PictureUri { get; init; }
    public required string Brand { get; init; }
}