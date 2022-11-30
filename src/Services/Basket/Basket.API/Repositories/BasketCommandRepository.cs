using System.Text.Json;
using Hermes.Basket.API.Entities;
using StackExchange.Redis;

namespace Hermes.Basket.API.Repositories;

public class BasketCommandRepository : IBasketCommandRepository
{
    private readonly IDatabase _database;

    public BasketCommandRepository(IConnectionMultiplexer connectionMultiplexer) =>
        _database = connectionMultiplexer.GetDatabase();

    public async Task DeleteAsync(Guid id, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        await _database.KeyDeleteAsync(id.ToString());
    }

    public async Task<CustomerBasket> UpdateAsync(
        CustomerBasket entity,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        var created = await _database.StringSetAsync(entity.CustomerId.ToString(), JsonSerializer.Serialize(entity));
        return entity;
    }

    public async Task UpdateManyAsync(
        IEnumerable<CustomerBasket> entities,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
            await UpdateAsync(entity, autoSave, cancellationToken);
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return Task.CompletedTask;
    }
}