using Hermes.Client.Web.Models.Admin.Brands;
using Hermes.Client.Web.Models.Admin.Items;
using Hermes.Client.Web.Models.Admin.ItemTypes;
using Hermes.Client.Web.Requests;
using Hermes.Client.Web.Services.Models.Admin;

namespace Hermes.Client.Web.Mappings;

internal static class AdminMappings
{
    public static ItemsViewModel ToItemsViewModel(this GetItemsServiceModel model) =>
        new()
        {
            Items = model.Items.Select(ToItemViewModel),
        };

    public static ItemViewModel ToItemViewModel(this GetItemServiceModel model) =>
        new()
        {
            Id = model.Id,
            Name = model.Name,
        };

    public static BrandsViewModel ToBrandsViewModel(this GetBrandsServiceModel model) =>
        new()
        {
            Brands = model.Brands.Select(ToBrandViewModel),
        };

    public static BrandViewModel ToBrandViewModel(this GetBrandServiceModel model) =>
        new()
        {
            Id = model.Id,
            Name = model.Name,
        };

    public static ItemTypesViewModel ToItemTypesViewModel(this GetItemTypesServiceModel model) =>
        new()
        {
            ItemTypes = model.ItemTypes.Select(ToItemTypeViewModel),
        };

    public static ItemTypeViewModel ToItemTypeViewModel(this GetItemTypeServiceModel model) =>
        new()
        {
            Id = model.Id,
            Name = model.Name,
        };

    public static CreateItemServiceModel ToCreateItemServiceModel(this CreateItemRequest request) =>
        new()
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            AvailableStock = request.AvailableStock,
            PictureUri = request.PictureUri,
            BrandId = request.BrandId,
            TypeId = request.TypeId,
        };

    public static CreateItemTypeServiceModel ToCreateItemTypeServiceModel(this CreateItemTypeRequest request) =>
        new()
        {
            Name = request.Name,
        };

    public static CreateBrandServiceModel ToCreateBrandServiceModel(this CreateBrandRequest request) =>
        new()
        {
            Name = request.Name,
        };
}