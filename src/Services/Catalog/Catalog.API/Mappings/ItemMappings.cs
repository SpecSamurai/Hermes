using Hermes.Catalog.API.Entities;
using Hermes.Catalog.API.Requests.Items;
using Hermes.Catalog.API.Responses.Items;

namespace Hermes.Catalog.API.Mappings;

public static class ItemMappings
{
    public static DetailedItemGetResponse ToDetailedItemGetResponse(this Item item) =>
        new()
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            PictureFileName = item.PictureFileName,
            PictureUri = item.PictureUri,
            AvailableStock = item.AvailableStock,
            OnReorder = item.OnReorder,
            Type = item.Type!.ToItemTypeGetResponse(),
            Brand = item.Brand!.ToBrandGetResponse()
        };

    public static ItemGetResponse ToItemGetResponse(this Item item) =>
        new()
        {
            Id = item.Id,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            PictureFileName = item.PictureFileName,
            PictureUri = item.PictureUri,
            AvailableStock = item.AvailableStock,
            OnReorder = item.OnReorder,
            TypeId = item.TypeId,
            BrandId = item.BrandId
        };

    public static Item ToItemEntity(this ItemPostRequest request) =>
        new()
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

    public static ItemPatchRequest ToItemPatchRequest(this Item item) =>
        new()
        {
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            PictureFileName = item.PictureFileName,
            PictureUri = item.PictureUri,
            AvailableStock = item.AvailableStock,
            TypeId = item.TypeId,
            BrandId = item.BrandId
        };

    public static void Patch(this Item item, ItemPatchRequest patch)
    {
        item.Name = patch.Name;
        item.Description = patch.Description;
        item.Price = patch.Price;
        item.PictureFileName = patch.PictureFileName;
        item.PictureUri = patch.PictureUri;
        item.AvailableStock = patch.AvailableStock;
        item.TypeId = patch.TypeId;
        item.BrandId = patch.BrandId;
    }
}