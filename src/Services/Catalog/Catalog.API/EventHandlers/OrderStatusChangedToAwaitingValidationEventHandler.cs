using Hermes.Catalog.API.Events;
using Hermes.Catalog.API.Repositories.Items;
using Hermes.Catalog.API.Events.Models;
using Hermes.Catalog.API.Entities;

namespace Hermes.Catalog.API.EventHandlers;

public class OrderStatusChangedToAwaitingValidationEventHandler
    : IHandleMessages<OrderStatusChangedToAwaitingValidationEvent>
{
    private readonly IItemQueryRepository _itemRepository;

    public OrderStatusChangedToAwaitingValidationEventHandler(IItemQueryRepository itemRepository) =>
        _itemRepository = itemRepository;

    public async Task Handle(
        OrderStatusChangedToAwaitingValidationEvent @event,
        IMessageHandlerContext messageHandlerContext)
    {
        var catalogItems = await _itemRepository.GetListAsync(
            @event.GetOrderStockItemIds(),
            entity => entity,
            cancellationToken: messageHandlerContext.CancellationToken);

        var validatedOrderStockItems = @event.GetValidatedOrderStockItems(catalogItems);

        if (validatedOrderStockItems.Any(stockItem => stockItem.HasStock is false))
            await messageHandlerContext.Publish(new OrderStockRejectedEvent
            {
                OrderId = @event.OrderId,
                OrderStockItems = validatedOrderStockItems
            });
        else
            await messageHandlerContext.Publish(new OrderStockConfirmedEvent { OrderId = @event.OrderId });
    }
}

file static class OrderStatusChangedToAwaitingValidationEventHandlerExtensions
{
    public static IEnumerable<Guid> GetOrderStockItemIds(this OrderStatusChangedToAwaitingValidationEvent @event) =>
        @event.OrderStockItems.Select(stockItem => stockItem.ItemId);

    public static List<ValidatedOrderStockItem> GetValidatedOrderStockItems(
        this OrderStatusChangedToAwaitingValidationEvent @event,
        IEnumerable<Item> items) =>
            @event.OrderStockItems
                .Select(orderStockItem => new ValidatedOrderStockItem
                {
                    ItemId = orderStockItem.ItemId,
                    HasStock = orderStockItem.IsInStock(items)
                })
                .ToList();

    private static bool IsInStock(this AwaitingValidationOrderStockItem orderStockItem, IEnumerable<Item> items) =>
        items.Any(item => item.Id == orderStockItem.ItemId && item.AvailableStock >= orderStockItem.Units);
}