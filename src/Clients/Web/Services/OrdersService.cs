using Hermes.Client.Web.Constants;
using Hermes.Client.Web.Options;
using Hermes.Frameworks.Functional.Results;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;

namespace Hermes.Client.Web.Services;

public class OrdersService : IOrdersService
{
    public Task<IResult<PageResponse<OrderGetResponse>>> GetPageAsync(int pageIndex)
    {
        return Task.FromResult<IResult<PageResponse<OrderGetResponse>>>(
            new PageResponse<OrderGetResponse>()
            {
                PageIndex = pageIndex,
                Data = new List<OrderGetResponse>
                {
                    new OrderGetResponse
                    {
                        Id = Guid.NewGuid(),
                        Products = new List<OrderedProductGetResponse>
                        {
                            new OrderedProductGetResponse
                            {
                                Name = "Product 1"
                            },
                            new OrderedProductGetResponse
                            {
                                Name = "Product 2"
                            },
                            new OrderedProductGetResponse
                            {
                                Name = "Product 3"
                            }
                        },
                        Price = 100,
                        Date = DateTime.Now,
                        Status = "Paid"
                    }
                }
            }.ToSuccess()
        );
    }
}