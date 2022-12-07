using Hermes.Basket.API.Constants;
using Redis.OM.Modeling;
using StorageType = Redis.OM.Modeling.StorageType;

namespace Hermes.Basket.API.Entities;

[Document(
    StorageType = StorageType.Json,
    IndexName = EntitySettings.CustomerBasket.IndexName,
    Prefixes = new[] { EntitySettings.CustomerBasket.Prefix })]
public class CustomerBasket
{
    [RedisIdField][Indexed] public Guid Id { get; set; }
    [Indexed] public List<BasketItem> Items { get; set; } = new();
}