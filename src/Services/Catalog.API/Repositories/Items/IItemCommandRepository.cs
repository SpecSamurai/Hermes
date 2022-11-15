using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.Command;

namespace Hermes.Catalog.API.Repositories.Items;

public interface IItemCommandRepository :
    IInsertCommandRepository<Item>,
    IUpdateCommandRepository<Item>,
    IDeleteByEntityCommandRepository<Item>
{
}