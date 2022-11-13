using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.ReadOnly;

namespace Hermes.Catalog.API.Repositories.ItemTypes;

public interface IItemTypeQueryRepository :
    IQueryByIdRepository<ItemType, Guid>,
    IQueryByPredicateRepository<ItemType>,
    IQueryListRepository<ItemType>
{
}