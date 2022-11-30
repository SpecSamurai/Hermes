using Hermes.Basket.API.Entities;
using StackExchange.Redis;
using System.Linq.Expressions;
using System.Text.Json;

namespace Hermes.Basket.API.Repositories;

public class BasketQueryRepository : IBasketQueryRepository
{
    private readonly IDatabase _database;
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    public BasketQueryRepository(IConnectionMultiplexer connectionMultiplexer)
    {
        _connectionMultiplexer = connectionMultiplexer;
        _database = connectionMultiplexer.GetDatabase();
    }

    public async Task<CustomerBasket?> FindAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        string? data = await _database.StringGetAsync(id.ToString());

        return string.IsNullOrWhiteSpace(data) is false
            ? JsonSerializer.Deserialize<CustomerBasket>(data)
            : default;
    }

    public async Task<List<TResult>> GetListAsync<TResult>(
        IEnumerable<Guid> ids,
        Expression<Func<CustomerBasket, TResult>> selector,
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        var keys = ids.Select(id => new RedisKey(id.ToString())).ToArray();
        var data = await _database.StringGetAsync(keys);

        return data
            .Where(basket => basket.IsNullOrEmpty is false)
            .Select(basket => JsonSerializer.Deserialize<CustomerBasket>(basket!)!)
            .Select(selector.Compile())
            .ToList();
    }
}