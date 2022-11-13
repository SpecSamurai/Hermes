using Hermes.Catalog.API.Entities;
using Hermes.Catalog.API.Requests.Brands;
using Hermes.Catalog.API.Responses;

namespace Hermes.Catalog.API.Mappings;

public static class BrandMappings
{
    public static BrandGetResponse ToBrandGetResponse(this Brand brand) =>
        new BrandGetResponse
        {
            Name = brand.Name
        };

    public static PageResponse<BrandGetResponse> ToPageResponse(this IEnumerable<Brand> brands, int pageIndex, int pageSize)
    {
        var data = brands.Select(ToBrandGetResponse).ToList();
        return new PageResponse<BrandGetResponse>(pageIndex, pageSize, data.Count, data);
    }

    public static Brand ToBrandEntity(this BrandPostRequest request) =>
        new Brand
        {
            Name = request.Name
        };
}