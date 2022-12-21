namespace Hermes.Client.Web.Models;

internal class CatalogViewModel
{
    public required IEnumerable<ProductViewModel> Products { get; init; }
}