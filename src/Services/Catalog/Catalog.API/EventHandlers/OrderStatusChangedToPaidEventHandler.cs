using Hermes.Catalog.API.Constants;
using Hermes.Catalog.API.Entities;
using Hermes.Catalog.API.Events;
using Hermes.Catalog.API.Events.Models;
using Hermes.Catalog.API.Repositories.Items;

namespace Hermes.Catalog.API.EventHandlers;

public class OrderStatusChangedToPaidEventHandler : IHandleMessages<OrderStatusChangedToPaidEvent>
{
    private readonly IItemQueryRepository _itemQueryRepository;

    public OrderStatusChangedToPaidEventHandler(IItemQueryRepository itemQueryRepository) =>
        _itemQueryRepository = itemQueryRepository;

    public async Task Handle(OrderStatusChangedToPaidEvent @event, IMessageHandlerContext messageHandlerContext)
    {
        var catalogItems = await _itemQueryRepository.GetListAsync(
            @event.OrderStockItems.Select(item => item.ItemId),
            item => item,
            cancellationToken: messageHandlerContext.CancellationToken);

        var matchedItems = Match(@event.OrderStockItems, catalogItems);

        foreach (var (orderStockItem, catalogItem) in matchedItems)
        {
            catalogItem.AvailableStock -= catalogItem.AvailableStock >= orderStockItem.Units
                ? orderStockItem.Units
                : throw new InvalidOperationException(ErrorCodes.Items.NotEnoughStock);
        }
    }

    private static List<(PaidOrderStockItem, Item)> Match(
        IEnumerable<PaidOrderStockItem> paidOrderStockItems,
        IEnumerable<Item> items) =>
            paidOrderStockItems
                .GroupJoin(
                    @items,
                    orderStockitem => orderStockitem.ItemId,
                    catalogItems => catalogItems.Id,
                    (orderStockItem, catalogItem) => (orderStockItem, catalogItem.Single()))
                .ToList();
}