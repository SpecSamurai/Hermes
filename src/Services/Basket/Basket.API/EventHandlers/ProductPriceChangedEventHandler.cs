using Hermes.Basket.API.Events;
using Hermes.Basket.API.Repositories;
using Hermes.Frameworks.Repositories.DataStructures;

namespace Hermes.Basket.API.EventHandlers;

public class ProductPriceChangedEventHandler : IHandleMessages<ItemPriceChangedEvent>
{
    private readonly IBasketQueryRepository _basketQueryRepository;
    private readonly IBasketCommandRepository _basketCommandRepository;

    public ProductPriceChangedEventHandler(
        IBasketQueryRepository basketQueryRepository,
        IBasketCommandRepository basketCommandRepository)
    {
        _basketQueryRepository = basketQueryRepository;
        _basketCommandRepository = basketCommandRepository;
    }

    public async Task Handle(ItemPriceChangedEvent @event, IMessageHandlerContext context)
    {
        var baskets = await _basketQueryRepository.GetPageAsync(Offset.Of(0, 1000), basket => basket, string.Empty);

        foreach (var basket in baskets)
        {
            var itemToUpdate = basket.Items.FirstOrDefault(item => item.ProductId == @event.ItemId);
            if (itemToUpdate is not null)
            {
                itemToUpdate.Price = @event.NewPrice;
                await _basketCommandRepository.UpdateAsync(basket);
            }
        }
    }
}