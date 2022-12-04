namespace Hermes.Basket.API.Requests;

public class BasketItemPatchRequest
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public required string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? PictureUri { get; set; }
}