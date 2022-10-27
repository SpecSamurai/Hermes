using Hermes.Catalog.API.Options;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtenstions
{
    public static void AddCustomOptions(this IServiceCollection serviceCollection)
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
    }
}