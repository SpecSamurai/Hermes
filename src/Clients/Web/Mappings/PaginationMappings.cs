using Hermes.Client.Web.Configurations;
using Hermes.Client.Web.Models.Shared;
using Hermes.Client.Web.Responses;

namespace Hermes.Client.Web.Mappings;

static class PaginationMappings
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