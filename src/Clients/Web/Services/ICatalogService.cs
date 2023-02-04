using Hermes.Frameworks.Functional.Results;

namespace Hermes.Client.Web.Services;

public interface ICatalogService
{
    Task<IResult<PageResponse<ItemGetResponse>>> GetPageAsync(int pageIndex);
}