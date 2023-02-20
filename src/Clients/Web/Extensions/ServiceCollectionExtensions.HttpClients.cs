using Hermes.Client.Web.Constants;
using Hermes.Client.Web.Options;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static void RegisterHttpClients(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddHttpClient(HttpClients.CatalogApi, (serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<CatalogApiOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseAddress);
            });

        serviceCollection
            .AddHttpClient(HttpClients.OrderingApi, (serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<OrderingApiOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseAddress);
            });

        serviceCollection
            .AddHttpClient(HttpClients.PaymentApi, (serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<PaymentApiOptions>>().Value;
                client.BaseAddress = new Uri(options.BaseAddress);
            });
    }
}