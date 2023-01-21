namespace Hermes.Payment.Domain.Aggregates.PaymentRequest;

public enum PaymentRequestState
{
    Pending,
    Completed,
    Failed
}