using Hermes.Payment.API.Events;

namespace Hermes.Payment.API.EventHandlers;

public class OrderStatusChangedToStockConfirmedEventHandler : IHandleMessages<OrderStatusChangedToStockConfirmedEvent>
{
    public async Task Handle(
        OrderStatusChangedToStockConfirmedEvent @event,
        IMessageHandlerContext messageHandlerContext)
    {
        var paymentSucceeded = true;

        IEvent paymentEvent = paymentSucceeded
            ? new OrderPaymentSucceededEvent { OrderId = @event.OrderId }
            : new OrderPaymentFailedEvent { OrderId = @event.OrderId };

        await messageHandlerContext.Publish(paymentEvent);
    }
}