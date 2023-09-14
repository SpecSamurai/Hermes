using Hermes.Catalog.API.Responses;
using Hermes.Frameworks.Repositories.DataStructures;

namespace Hermes.Catalog.API.Mappings;

public static class PageMappings
{
    public static PageResponse<T> ToPageResponse<T>(this Page<T> page) =>
        new()
        {
            Data = page,
            TotalCount = page.TotalCount,
            TotalPages = page.TotalPages,
            PageIndex = page.PageIndex,
            PageSize = page.PageSize
        };
}