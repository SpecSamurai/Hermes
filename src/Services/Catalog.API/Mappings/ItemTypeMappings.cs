using Hermes.Catalog.API.Entities;
using Hermes.Catalog.API.Requests;
using Hermes.Catalog.API.Requests.ItemTypes;
using Hermes.Catalog.API.Responses;

namespace Hermes.Catalog.API.Mappings;

public static class ItemTypeMappings
{
    public static ItemTypeGetResponse ToItemTypeGetResponse(this ItemType itemType) =>
        new ItemTypeGetResponse
        {
            Name = itemType.Name
        };

    public static PageResponse<ItemTypeGetResponse> ToPageResponse(this IEnumerable<ItemType> itemType, int pageIndex, int pageSize)
    {
        var data = itemType.Select(ToItemTypeGetResponse).ToList();
        return new PageResponse<ItemTypeGetResponse>(pageIndex, pageSize, data.Count, data);
    }

    public static ItemType ToItemTypeEntity(this ItemTypePostRequest request) =>
        new ItemType
        {
            Name = request.Name
        };
}