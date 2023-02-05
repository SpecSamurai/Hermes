using Hermes.Client.Web.Constants;
using Hermes.Client.Web.Options;
using Hermes.Frameworks.Functional.Results;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;

namespace Hermes.Client.Web.Services;

public class PaymentsService : IPaymentsService
{
    public Task<IResult<PageResponse<PaymentGetResponse>>> GetPageAsync(int pageIndex)
    {
        return Task.FromResult<IResult<PageResponse<PaymentGetResponse>>>(
            new PageResponse<PaymentGetResponse>
            {
                PageIndex = pageIndex,
                Data = new List<PaymentGetResponse>
                {
                    new PaymentGetResponse
                    {
                        Id = Guid.NewGuid(),
                        OrderId = Guid.NewGuid(),
                        Price = 100,
                        Date = DateTime.Now,
                        Status = "Paid"
                    },
                    new PaymentGetResponse
                    {
                        Id = Guid.NewGuid(),
                        OrderId = Guid.NewGuid(),
                        Price = 100,
                        Date = DateTime.Now,
                        Status = "Paid"
                    },
                    new PaymentGetResponse
                    {
                        Id = Guid.NewGuid(),
                        OrderId = Guid.NewGuid(),
                        Price = 100,
                        Date = DateTime.Now,
                        Status = "Paid"
                    },
                }
            }.ToSuccess()
        );
    }
}