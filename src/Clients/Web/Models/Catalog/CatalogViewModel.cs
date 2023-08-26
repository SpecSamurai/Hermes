using Hermes.Client.Web.Models.Shared;

namespace Hermes.Client.Web.Models.Catalog;

class CatalogViewModel
{
    public required PaginationViewModel Pagination { get; init; }
    public required IEnumerable<ProductViewModel> Products { get; init; }
    public required CatalogScriptViewModel CatalogScript { get; init; }
}