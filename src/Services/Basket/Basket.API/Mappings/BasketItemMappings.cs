using Hermes.Basket.API.Entities;
using Hermes.Basket.API.Requests;
using Hermes.Basket.API.Responses;

namespace Hermes.Basket.API.Mappings;

public static class BasketItemMappings
{
    public static BasketItemGetResponse ToBasketItemGetResponse(this BasketItem basketItem) =>
        new()
        {
            ProductId = basketItem.ProductId,
            ProductName = basketItem.ProductName,
            Price = basketItem.Price,
            Quantity = basketItem.Quantity,
            PictureUri = basketItem.PictureUri
        };

    public static BasketItemPatchRequest ToBasketItemPatchRequest(this BasketItem item) =>
        new()
        {
            ProductId = item.ProductId,
            ProductName = item.ProductName,
            Price = item.Price,
            Quantity = item.Quantity,
            PictureUri = item.PictureUri
        };

    public static BasketItem ToBasketItem(this BasketItemPostRequest request) =>
        new()
        {
            ProductId = request.ProductId,
            ProductName = request.ProductName,
            Price = request.Price,
            Quantity = request.Quantity,
            PictureUri = request.PictureUri
        };

    public static BasketItem ToBasketItem(this BasketItemPatchRequest request) =>
        new()
        {
            ProductId = request.ProductId,
            ProductName = request.ProductName,
            Price = request.Price,
            Quantity = request.Quantity,
            PictureUri = request.PictureUri
        };
}