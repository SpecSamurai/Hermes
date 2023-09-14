using Hermes.Catalog.API.Entities;
using Hermes.Catalog.API.Requests.ItemTypes;
using Hermes.Catalog.API.Responses;

namespace Hermes.Catalog.API.Mappings;

public static class ItemTypeMappings
{
    public static ItemTypeGetResponse ToItemTypeGetResponse(this ItemType itemType) =>
        new()
        {
            Id = itemType.Id,
            Name = itemType.Name
        };

    public static ItemType ToItemTypeEntity(this ItemTypePostRequest request) =>
        new()
        {
            Name = request.Name
        };

    public static ItemTypePatchRequest ToItemTypePatchRequest(this ItemType itemType) =>
        new()
        {
            Name = itemType.Name
        };

    public static void Patch(this ItemType itemType, ItemTypePatchRequest patch)
    {
        itemType.Name = patch.Name;
    }
}