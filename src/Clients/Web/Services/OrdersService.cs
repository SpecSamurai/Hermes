using Hermes.Client.Web.Constants;
using Hermes.Client.Web.Options;
using Hermes.Frameworks.Functional.Results;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;

namespace Hermes.Client.Web.Services;

public class OrdersService : IOrdersService
{
    private readonly OrderingApiOptions orderingApiOptions;
    private readonly IHttpClientFactory httpClientFactory;

    public OrdersService(
        IOptions<OrderingApiOptions> orderingApiOptions,
        IHttpClientFactory httpClientFactory)
    {
        this.orderingApiOptions = orderingApiOptions.Value;
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<IResult<PageResponse<OrderGetResponse>>> GetPageAsync(int pageIndex)
    {
        var httpClient = httpClientFactory.CreateClient(HttpClients.OrderingApi);
        var response = await httpClient.GetAsync(GetUri(pageIndex));

        return
            response.IsSuccessStatusCode &&
            await response.Content.ReadFromJsonAsync<PageResponse<OrderGetResponse>>() is PageResponse<OrderGetResponse> page
                ? page.ToSuccess()
                : Result.Failure<PageResponse<OrderGetResponse>>(
                    ErrorCodes.Ordering.GetPageFailed,
                    (nameof(response.StatusCode), response.StatusCode));
    }

    private Uri GetUri(int pageIndex)
    {
        var queryString = GetQueryString(pageIndex);
        var uri = orderingApiOptions.OrdersEndpointPath + queryString;

        return new Uri(uri, UriKind.Relative);
    }

    private static QueryString GetQueryString(int pageIndex)
    {
        var queryString = new QueryBuilder
        {
            { "index", pageIndex.ToString() },
            { "size", "12" },
            { "sorting", "name" }
        };

        return queryString.ToQueryString();
    }
}