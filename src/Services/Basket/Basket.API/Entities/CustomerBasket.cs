namespace Hermes.Basket.API.Entities;

public class CustomerBasket
{
    public Guid CustomerId { get; set; }
    public List<BasketItem> Items { get; set; } = new();
}