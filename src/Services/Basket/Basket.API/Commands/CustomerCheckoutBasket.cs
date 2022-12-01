namespace Hermes.Basket.API.Commands;

public record CustomerCheckoutBasket
{
    public Guid CustomerId { get; set; }
    public List<CustomerCheckoutBasketItem> Items { get; set; } = new();
}