using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.Query;

namespace Hermes.Catalog.API.Repositories.Items;

public interface IItemQueryRepository :
    IGetByIdQueryRepository<Guid, Item>,
    IGetByPredicateQueryRepository<Item>,
    IListQueryRepository<Item>
{
}