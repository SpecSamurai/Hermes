using Hermes.Frameworks.Functional.Results;

namespace Hermes.Client.Web.Services;

public interface IOrdersService
{
    Task<IResult<PageResponse<OrderGetResponse>>> GetPageAsync(int pageIndex);
}