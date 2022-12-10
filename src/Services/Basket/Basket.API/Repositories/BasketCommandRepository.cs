using Hermes.Basket.API.Entities;
using Redis.OM;
using Redis.OM.Searching;

namespace Hermes.Basket.API.Repositories;

public class BasketCommandRepository : IBasketCommandRepository
{
    private readonly IRedisCollection<CustomerBasket> _customerBaskets;
    public BasketCommandRepository(RedisConnectionProvider redisConnectionProvider) =>
        _customerBaskets = redisConnectionProvider.RedisCollection<CustomerBasket>();

    public async Task DeleteAsync(
        Guid id,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        var entity = await _customerBaskets.SingleAsync(basket => basket.Id == id);
        await _customerBaskets.DeleteAsync(entity);
    }

    public async Task<CustomerBasket> UpdateAsync(
        CustomerBasket entity,
        bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        await _customerBaskets.UpdateAsync(entity);
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

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _customerBaskets.SaveAsync();
    }
}