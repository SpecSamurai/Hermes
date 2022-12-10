using System.ComponentModel;
using System.Linq.Expressions;
using Hermes.Basket.API.Entities;
using Hermes.Frameworks.Repositories.DataStructures;
using Redis.OM;
using Redis.OM.Searching;

namespace Hermes.Basket.API.Repositories;

public class BasketQueryRepository : IBasketQueryRepository
{
    private IRedisCollection<CustomerBasket> _customerBaskets;

    public BasketQueryRepository(RedisConnectionProvider redisConnectionProvider) =>
        _customerBaskets = redisConnectionProvider.RedisCollection<CustomerBasket>();

    public async Task<CustomerBasket?> FindAsync(
        Guid id,
        bool includeDetails = true,
        CancellationToken cancellationToken = default) =>
            await _customerBaskets.FindByIdAsync(id.ToString());

    public async Task<IList<TResult>> GetPageAsync<TResult>(
        Offset offset,
        Expression<Func<CustomerBasket, TResult>> selector,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) where TResult : notnull
    {
        var property = TypeDescriptor.GetProperties(typeof(CustomerBasket)).Find(sorting, ignoreCase: false);

        var query = property is not null
            ? _customerBaskets.OrderBy(entity => property.GetValue(entity))
            : _customerBaskets;

        return await query
            .Skip(offset.Skip)
            .Take(offset.Take)
            .Select(selector)
            .ToListAsync();
    }

    public async Task<IList<TResult>> GetPageAsync<TResult>(
        Keyset<CustomerBasket> keyset,
        Expression<Func<CustomerBasket, TResult>> selector,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) where TResult : notnull
    {
        var property = TypeDescriptor.GetProperties(typeof(CustomerBasket)).Find(sorting, ignoreCase: false);

        var query = property is not null
            ? _customerBaskets.OrderBy(entity => property.GetValue(entity))
            : _customerBaskets;

        return await query
            .Where(keyset.Predicate)
            .Take(keyset.Take)
            .Select(selector)
            .ToListAsync();
    }
}