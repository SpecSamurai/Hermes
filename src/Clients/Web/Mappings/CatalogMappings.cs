using Hermes.Client.Web.Configurations;
using Hermes.Client.Web.Models.Catalog;
using Hermes.Client.Web.Options;

namespace Hermes.Client.Web.Mappings;

internal static class CatalogMappings
{
    public static CatalogViewModel ToCatalogViewModel(
        this PageResponse<ItemGetResponse> response,
        PaginationViewConfiguration configuration,
        BasketApiOptions options) =>
            new()
            {
                Pagination = response.ToPaginationViewModel(configuration),
                Products = response.Data.Select(ToProductViewModel),
                CatalogScript = options.ToCatalogScriptViewModel()
            };

    public static ProductViewModel ToProductViewModel(this ItemGetResponse response) =>
        new()
        {
            Name = response.Name,
            Description = response.Description ?? string.Empty,
            Price = response.Price,
            PictureUri = response.PictureUri ?? string.Empty,
            Brand = response.BrandId.ToString()
        };

    public static CatalogScriptViewModel ToCatalogScriptViewModel(this BasketApiOptions options) =>
        new()
        {
            BaseAddress = options.BaseAddress,
            BasketEndpointPath = options.BasketEndpointPath,
            Hub = options.Hub
        };
}