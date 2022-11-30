namespace Hermes.Basket.API.Events;

public class ItemPriceChangedEvent : IEvent
{
    public Guid ItemId { get; init; }
    public decimal NewPrice { get; init; }
    public decimal OldPrice { get; init; }
}