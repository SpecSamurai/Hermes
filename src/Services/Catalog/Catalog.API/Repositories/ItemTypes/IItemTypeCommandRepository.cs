using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.Command;

namespace Hermes.Catalog.API.Repositories.ItemTypes;

public interface IItemTypeCommandRepository :
    IInsertCommandRepository<ItemType>,
    IUpdateCommandRepository<ItemType>,
    IDeleteByEntityCommandRepository<ItemType>
{
}