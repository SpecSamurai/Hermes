using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.ReadOnly;

namespace Hermes.Catalog.API.Repositories.Items;

public interface IItemQueryRepository :
    IQueryByIdRepository<Item, Guid>,
    IQueryByPredicateRepository<Item>,
    IQueryListRepository<Item>
{
}