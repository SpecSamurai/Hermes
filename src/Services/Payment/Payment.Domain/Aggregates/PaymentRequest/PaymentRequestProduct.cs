using Hermes.Frameworks.DDD.Entities;
using Hermes.Frameworks.Functional.Fintech;

namespace Hermes.Payment.Domain.Aggregates.PaymentRequest;

public class PaymentRequestProduct : Entity<Guid>
{
    public PaymentRequestProduct(
        Guid id,
        Guid paymentRequestId,
        string code,
        string name,
        int quantity,
        Money unitPrice) : base(id)
    {
        PaymentRequestId = paymentRequestId;
        Code = code;
        Name = name;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public Guid PaymentRequestId { get; }
    public string Code { get; }
    public string Name { get; }
    public int Quantity { get; }
    public Money UnitPrice { get; }

    public Money TotalPrice =>
        Quantity * UnitPrice;
}