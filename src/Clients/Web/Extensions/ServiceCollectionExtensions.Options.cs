using Hermes.Client.Web.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static void RegisterOptions(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddOptions<CatalogApiOptions>()
            .Configure<IConfiguration>((settings, configuration) =>
                configuration
                    .GetSection(nameof(CatalogApiOptions))
                    .Bind(settings))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddOptions<BasketApiOptions>()
            .Configure<IConfiguration>((settings, configuration) =>
                configuration
                    .GetSection(nameof(BasketApiOptions))
                    .Bind(settings))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddOptions<OrderingApiOptions>()
            .Configure<IConfiguration>((settings, configuration) =>
                configuration
                    .GetSection(nameof(OrderingApiOptions))
                    .Bind(settings))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddOptions<PaymentApiOptions>()
            .Configure<IConfiguration>((settings, configuration) =>
                configuration
                    .GetSection(nameof(PaymentApiOptions))
                    .Bind(settings))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddOptions<PaginationOptions>()
            .Configure<IConfiguration>((settings, configuration) =>
                configuration
                    .GetSection(nameof(PaginationOptions))
                    .Bind(settings))
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}