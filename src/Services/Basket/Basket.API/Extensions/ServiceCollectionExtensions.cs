using Hermes.Basket.API.Constants;
using Hermes.Basket.API.Repositories;
using Redis.OM;
using StackExchange.Redis;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRedisConnectionProvider(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddSingleton<RedisConnectionProvider>(serviceProvider =>
        {
            var connectionString = serviceProvider
                .GetRequiredService<IConfiguration>()
                .GetConnectionString("BasketDatabase")
                ?? throw new InvalidOperationException(ErrorCodes.Redis.InvalidConnectionString);

            return new RedisConnectionProvider(ConnectionMultiplexer.Connect(connectionString));
        });
    }

    public static IServiceCollection AddDependencies(this IServiceCollection serviceCollection) =>
        serviceCollection
            .AddScoped<IBasketQueryRepository, BasketQueryRepository>()
            .AddScoped<IBasketCommandRepository, BasketCommandRepository>();
}