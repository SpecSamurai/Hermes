namespace Hermes.Basket.API.Requests;

public class CustomerBasketPatchRequest
{
    public List<BasketItemPatchRequest> Items { get; init; } = new();
}