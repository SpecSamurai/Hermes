using Hermes.Catalog.API.Entities;
using Hermes.Catalog.API.Requests.Items;
using Hermes.Catalog.API.Responses;

namespace Hermes.Catalog.API.Mappings;

public static class ItemMappings
{
    public static ItemGetResponse ToItemGetResponse(this Item item) =>
        new ItemGetResponse
        {
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            PictureFileName = item.PictureFileName,
            PictureUri = item.PictureUri,
            AvailableStock = item.AvailableStock,
            OnReorder = item.OnReorder,
            Type = item.Type?.ToItemTypeGetResponse(),
            TypeId = item.TypeId,
            Brand = item.Brand?.ToBrandGetResponse(),
            BrandId = item.BrandId
        };

    public static PageResponse<ItemGetResponse> ToPageResponse(this IEnumerable<Item> items, int pageIndex, int pageSize)
    {
        var data = items.Select(ToItemGetResponse).ToList();
        return new PageResponse<ItemGetResponse>(pageIndex, pageSize, data.Count, data);
    }

    public static Item ToItemEntity(this ItemPostRequest request) =>
        new Item
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            PictureFileName = request.PictureFileName,
            PictureUri = request.PictureUri,
            AvailableStock = request.AvailableStock,
            TypeId = request.TypeId,
            BrandId = request.BrandId
        };

    // public void Update(ItemPatchRequest itemPatch)
    // {
    //     Name = itemPatch.Name ?? Name;
    //     Description = itemPatch.Description;
    //     Price = itemPatch.Price ?? Price;
    //     PictureFileName = itemPatch.PictureFileName;
    //     PictureUri = itemPatch.PictureUri;
    //     AvailableStock = itemPatch.AvailableStock ?? AvailableStock;
    //     OnReorder = itemPatch.OnReorder ?? OnReorder;
    //     TypeId = itemPatch.TypeId ?? TypeId;
    //     BrandId = itemPatch.BrandId ?? BrandId;
    // }
}