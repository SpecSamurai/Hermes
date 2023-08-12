using Hermes.Client.Web.Constants;
using Hermes.Client.Web.Options;
using Hermes.Frameworks.Functional.Results;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;

namespace Hermes.Client.Web.Services;

public class PaymentsService : IPaymentsService
{
    private readonly PaymentApiOptions paymentApiOptions;
    private readonly IHttpClientFactory httpClientFactory;

    public PaymentsService(
        IOptions<PaymentApiOptions> paymentApiOptions,
        IHttpClientFactory httpClientFactory)
    {
        this.paymentApiOptions = paymentApiOptions.Value;
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<IResult<PageResponse<PaymentGetResponse>>> GetPageAsync(int pageIndex)
    {
        var httpClient = httpClientFactory.CreateClient(HttpClients.PaymentApi);
        var response = await httpClient.GetAsync(GetUri(pageIndex));

        return
            response.IsSuccessStatusCode &&
            await response.Content.ReadFromJsonAsync<PageResponse<PaymentGetResponse>>() is PageResponse<PaymentGetResponse> page
                ? page.ToSuccess()
                : Result.Failure<PageResponse<PaymentGetResponse>>(
                    ErrorCodes.Ordering.GetPageFailed,
                    (nameof(response.StatusCode), response.StatusCode));
    }

    private Uri GetUri(int pageIndex)
    {
        var queryString = GetQueryString(pageIndex);
        var uri = paymentApiOptions.GetPaymentsEndpointPath + queryString;

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