namespace Hermes.Basket.API.Requests;

public class CustomerBasketPostRequest
{
    public Guid Id { get; init; }
    public List<BasketItemPostRequest> Items { get; init; } = new();
}