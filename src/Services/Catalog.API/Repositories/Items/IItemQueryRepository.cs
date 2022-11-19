using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.Query;

namespace Hermes.Catalog.API.Repositories.Items;

public interface IItemQueryRepository :
    IGetByIdNullableQueryRepository<Guid, Item>,
    IListQueryRepository<Item>,
    IPaginationQueryRepository<Item>
{
}