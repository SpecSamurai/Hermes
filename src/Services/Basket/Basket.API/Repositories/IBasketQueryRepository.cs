using Hermes.Basket.API.Entities;
using Hermes.Frameworks.Repositories.Query;

namespace Hermes.Basket.API.Repositories;

public interface IBasketQueryRepository :
    IGetByIdNullableQueryRepository<Guid, CustomerBasket>,
    IPaginationQueryRepository<CustomerBasket>
{
}