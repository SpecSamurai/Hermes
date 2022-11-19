using Hermes.Catalog.API.Constants;
using Hermes.Catalog.API.Mappings;
using Hermes.Catalog.API.Repositories.ItemTypes;
using Hermes.Catalog.API.Requests.ItemTypes;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Catalog.API.Controller.V1.ItemTypes;

[ApiController]
[EndpointGroupName(ApiSettings.ApiVersion1)]
[Tags("Item Types Command")]
[Route($"{ApiSettings.ApiPrefix}/{ApiSettings.ApiVersion1}/{ApiSettings.ItemTypesEndpoint}")]
public class ItemTypesCommandController : ControllerBase
{
    private readonly IItemTypeQueryRepository _itemTypeQueryRepository;
    private readonly IItemTypeCommandRepository _itemTypeCommandRepository;

    public ItemTypesCommandController(
        IItemTypeQueryRepository itemTypeQueryRepository,
        IItemTypeCommandRepository itemTypeCommandRepository)
    {
        _itemTypeQueryRepository = itemTypeQueryRepository;
        _itemTypeCommandRepository = itemTypeCommandRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateAsync([FromBody] ItemTypePostRequest request)
    {
        var itemType = request.ToItemTypeEntity();
        await _itemTypeCommandRepository.InsertAsync(itemType, autoSave: true);

        return CreatedAtAction(nameof(CreateAsync), new { id = itemType.Id }, null);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var itemType = await _itemTypeQueryRepository.FindAsync(id);

        if (itemType is not null)
        {
            await _itemTypeCommandRepository.DeleteAsync(itemType, autoSave: true);
            return NoContent();
        }
        else return NotFound();
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> PatchAsync(Guid id, JsonPatchDocument<ItemTypePatchRequest> request)
    {
        var itemType = await _itemTypeQueryRepository.FindAsync(id);

        if (itemType is not null)
        {
            var patch = itemType.ToItemTypePatchRequest();
            request.ApplyTo(patch);
            itemType.Patch(patch);

            await _itemTypeCommandRepository.UpdateAsync(itemType, autoSave: true);
            return NoContent();
        }
        else return NotFound();
    }
}