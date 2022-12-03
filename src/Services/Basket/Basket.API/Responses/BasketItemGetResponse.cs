namespace Hermes.Basket.API.Responses;

public record BasketItemGetResponse
{
    public Guid ProductId { get; init; }
    public required string ProductName { get; init; }
    public decimal Price { get; init; }
    public int Quantity { get; init; }
    public string? PictureUri { get; init; }
}