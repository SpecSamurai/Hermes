using Hermes.Client.Web.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static void RegisterServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<ICatalogService, CatalogService>()
            .AddScoped<IOrdersService, OrdersService>()
            .AddScoped<IPaymentsService, PaymentsService>()
            .AddScoped<IAccountService, AccountService>();
    }
}