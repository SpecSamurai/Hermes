using Hermes.Frameworks.Repositories.Query;
using Hermes.Frameworks.Repositories.Command;
using Hermes.Payment.Domain.Aggregates.PaymentRequest;

namespace Hermes.Payment.Domain.Repositories;

public interface IPaymentRequestRepository :
    IGetByIdQueryRepository<Guid, PaymentRequest>,
    IGetByIdNullableQueryRepository<Guid, PaymentRequest>,
    IInsertCommandRepository<PaymentRequest>,
    IUpdateCommandRepository<PaymentRequest>
{
}