using Hermes.Client.Web.Configurations;
using Hermes.Client.Web.Models.Catalog;

namespace Hermes.Client.Web.Mappings;

internal static class CatalogMappings
{
    public static CatalogViewModel ToCatalogViewModel(
        this PageResponse<ItemGetResponse> response,
        PaginationViewConfiguration configuration) =>
            new()
            {
                Pagination = response.ToPaginationViewModel(configuration),
                Products = response.Data.Select(ToProductViewModel)
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
}