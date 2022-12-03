namespace Hermes.Basket.API.Responses;

public record CustomerBasketGetResponse
{
    public required IEnumerable<BasketItemGetResponse> Items { get; init; }
}