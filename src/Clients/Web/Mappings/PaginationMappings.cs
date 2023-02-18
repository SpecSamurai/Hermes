using Hermes.Client.Web.Configurations;
using Hermes.Client.Web.Models.Shared;

namespace Hermes.Client.Web.Mappings;

internal static class PaginationMappings
{
    public static PaginationViewModel ToPaginationViewModel<TModel>(
        this PageResponse<TModel> response,
        PaginationViewConfiguration configuration) =>
            new()
            {
                PageIndex = response.PageIndex,
                TotalPages = 12, //response.Total,
                MaxAdditionalPages = configuration.MaxAdditionalPages,
                PageUrl = configuration.PageUrl
            };
}