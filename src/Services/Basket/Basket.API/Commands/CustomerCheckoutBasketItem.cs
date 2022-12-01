namespace Hermes.Basket.API.Commands;

public class CustomerCheckoutBasketItem
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public required string ProductName { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? PictureUri { get; set; }
}