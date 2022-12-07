using Redis.OM.Modeling;

namespace Hermes.Basket.API.Entities;

public class BasketItem
{
    [Indexed] public Guid ProductId { get; set; }
    [Indexed] public required string ProductName { get; set; }
    [Indexed] public decimal Price { get; set; }
    [Indexed] public int Quantity { get; set; }
    [Indexed] public string? PictureUri { get; set; }
}