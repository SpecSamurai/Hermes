using Hermes.Catalog.API.Options;
using Hermes.Catalog.API.Repositories;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtenstions
{
    public static IServiceCollection AddCustomOptions(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddOptions<MigrationOptions>()
            .Configure<IConfiguration>((settings, configuration) =>
                configuration
                    .GetSection(nameof(MigrationOptions))
                    .Bind(settings))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddOptions<BusOptions>()
            .Configure<IConfiguration>((settings, configuration) =>
                configuration
                    .GetSection(nameof(BusOptions))
                    .Bind(settings))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return serviceCollection;
    }

    public static IServiceCollection AddDependencies(this IServiceCollection serviceCollection) =>
        serviceCollection.AddScoped<IItemRepository, ItemRepository>();
}