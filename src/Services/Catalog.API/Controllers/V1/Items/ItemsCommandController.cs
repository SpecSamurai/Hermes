using Hermes.Catalog.API.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using Hermes.Catalog.API.Mappings;
using Hermes.Catalog.API.Requests.Items;
using Hermes.Catalog.API.Repositories.Items;
using NServiceBus.TransactionalSession;
using Hermes.Catalog.API.Events;

namespace Hermes.Catalog.API.Controller.V1.Items;

[ApiController]
[EndpointGroupName(ApiSettings.ApiVersion1)]
[Tags("Items Command")]
[Route($"{ApiSettings.ApiPrefix}/{ApiSettings.ApiVersion1}/{ApiSettings.ItemsEndpoint}")]
public class ItemsCommandController : ControllerBase
{
    private readonly IItemQueryRepository _itemQueryRepository;
    private readonly IItemCommandRepository _itemCommandRepository;
    private readonly ITransactionalSession _transactionalSession;

    public ItemsCommandController(
        IItemQueryRepository itemQueryRepository,
        IItemCommandRepository itemCommandRepository,
        ITransactionalSession transactionalSession)
    {
        _itemQueryRepository = itemQueryRepository;
        _itemCommandRepository = itemCommandRepository;
        _transactionalSession = transactionalSession;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateAsync([FromBody] ItemPostRequest request)
    {
        var item = request.ToItemEntity();
        await _itemCommandRepository.InsertAsync(item, autoSave: true);

        return CreatedAtAction(nameof(CreateAsync), new { id = item.Id }, null);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var item = await _itemQueryRepository.FindAsync(id);

        if (item is not null)
        {
            await _itemCommandRepository.DeleteAsync(item, autoSave: true);
            return NoContent();
        }
        else return NotFound();
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> PatchAsync(Guid id, JsonPatchDocument<ItemPatchRequest> request)
    {
        var item = await _itemQueryRepository.FindAsync(id);

        if (item is not null)
        {
            var patch = item.ToItemPatchRequest();
            request.ApplyTo(patch);

            var oldPrice = item.Price;
            item.Patch(patch);

            await _itemCommandRepository.UpdateAsync(item);
            if (item.Price != oldPrice)
                await _transactionalSession.Publish(new ItemPriceChangedEvent
                {
                    ItemId = item.Id,
                    NewPrice = item.Price,
                    OldPrice = oldPrice
                });

            return NoContent();
        }
        else return NotFound();
    }
}