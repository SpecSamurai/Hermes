using Hermes.Basket.API.Constants;
using StackExchange.Redis;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRedisConnectionMultiplexer(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddSingleton<IConnectionMultiplexer>(serviceProvider =>
        {
            var connectionString = serviceProvider
                .GetRequiredService<IConfiguration>()
                .GetConnectionString("Redis")
                ?? throw new InvalidOperationException(ErrorCodes.Redis.InvalidConnectionString);

            return ConnectionMultiplexer.Connect(connectionString);
        });
    }
}