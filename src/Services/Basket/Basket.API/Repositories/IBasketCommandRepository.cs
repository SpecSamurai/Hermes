using Hermes.Basket.API.Entities;
using Hermes.Frameworks.Repositories.Command;

namespace Hermes.Basket.API.Repositories;

public interface IBasketCommandRepository :
    IUpdateCommandRepository<CustomerBasket>,
    IDeleteByIdCommandRepository<Guid, CustomerBasket>
{
}