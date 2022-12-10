using Hermes.Basket.API.Events;
using Hermes.Basket.API.Repositories;

namespace Hermes.Basket.API.EventHandlers;

public class OrderStartedEventHandler : IHandleMessages<OrderStartedEvent>
{
    private readonly IBasketCommandRepository _basketCommandRepository;

    public OrderStartedEventHandler(IBasketCommandRepository basketCommandRepository)
    {
        _basketCommandRepository = basketCommandRepository;
    }

    public async Task Handle(OrderStartedEvent @event, IMessageHandlerContext context)
    {
        await _basketCommandRepository.DeleteAsync(@event.CustomerId);
    }
}