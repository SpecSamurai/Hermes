using Hermes.Frameworks.Functional.Results;

namespace Hermes.Client.Web.Services;

public interface IPaymentsService
{
    Task<IResult<PageResponse<PaymentGetResponse>>> GetPageAsync(int pageIndex);
}