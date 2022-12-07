using Hermes.Basket.API.Entities;
using Hermes.Basket.API.Requests;
using Hermes.Basket.API.Responses;

namespace Hermes.Basket.API.Mappings;

public static class CustomerBasketMappings
{
    public static CustomerBasket ToCustomerBasket(this CustomerBasketPostRequest request) =>
        new()
        {
            Id = request.Id,
            Items = request.Items.Select(BasketItemMappings.ToBasketItem).ToList()
        };

    public static CustomerBasketGetResponse ToCustomerBasketGetResponse(this CustomerBasket customerBasket) =>
        new()
        {
            Items = customerBasket.Items.Select(BasketItemMappings.ToBasketItemGetResponse)
        };

    public static CustomerBasketPatchRequest ToCustomerBasketPatchRequest(this CustomerBasket customerBasket) =>
        new()
        {
            Items = customerBasket.Items.Select(BasketItemMappings.ToBasketItemPatchRequest).ToList()
        };

    public static void Patch(this CustomerBasket customerBasket, CustomerBasketPatchRequest customerBasketPatchRequest)
    {
        customerBasket.Items = customerBasketPatchRequest.Items.Select(BasketItemMappings.ToBasketItem).ToList();
    }
}