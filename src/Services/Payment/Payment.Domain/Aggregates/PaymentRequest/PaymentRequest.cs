using Hermes.Frameworks.DDD.Entities;
using Hermes.Payment.Domain.Events;

namespace Hermes.Payment.Domain.Aggregates.PaymentRequest;

public class PaymentRequest : AggregateRoot<Guid>
{
    public PaymentRequest(
        Guid id,
        Guid orderId,
        Guid buyerId,
        PaymentRequestState state,
        IEnumerable<PaymentRequestProduct> products) : base(id)
    {
        OrderId = orderId;
        BuyerId = buyerId;
        State = state;
        Products = products;
    }

    public Guid OrderId { get; }
    public Guid BuyerId { get; }
    public PaymentRequestState State { get; private set; }
    public IEnumerable<PaymentRequestProduct> Products { get; }

    public void SetAsCompleted()
    {
        if (State != PaymentRequestState.Completed)
        {
            State = PaymentRequestState.Completed;
            AddDistributedEvent(new PaymentRequestCompletedDomainEvent { PaymentRequestId = Id });
        }
    }

    public void SetAsFailed()
    {
        if (State != PaymentRequestState.Failed)
        {
            State = PaymentRequestState.Failed;
            AddDistributedEvent(new PaymentRequestFailedDomainEvent { PaymentRequestId = Id });
        }
    }
}