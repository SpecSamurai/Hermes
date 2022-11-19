using System.Net.Mime;
using Hermes.Catalog.API.Constants;
using Hermes.Catalog.API.Mappings;
using Hermes.Catalog.API.Repositories.ItemTypes;
using Hermes.Catalog.API.Requests;
using Hermes.Catalog.API.Responses;
using Hermes.Frameworks.Repositories.DataStructures;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Catalog.API.Controller.V1.ItemTypes;

[ApiController]
[EndpointGroupName(ApiSettings.ApiVersion1)]
[Tags("Item Types Query")]
[Route($"{ApiSettings.ApiPrefix}/{ApiSettings.ApiVersion1}/{ApiSettings.ItemTypesEndpoint}")]
public class ItemTypesQueryController : ControllerBase
{
    private readonly IItemTypeQueryRepository _itemTypeQueryRepository;

    public ItemTypesQueryController(IItemTypeQueryRepository itemTypeQueryRepository) =>
        _itemTypeQueryRepository = itemTypeQueryRepository;

    [HttpGet("{id:guid}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ItemGetResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var itemType = await _itemTypeQueryRepository.FindAsync(id);

        return itemType is not null
            ? Ok(itemType.ToItemTypeGetResponse())
            : NotFound(itemType);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(PageResponse<ItemGetResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetItemsPageAsync([FromQuery] PageRequest request)
    {
        var itemTypes = await _itemTypeQueryRepository.GetPageAsync(
            Offset.Of(request.Index, request.Size),
            entity => entity.ToItemTypeGetResponse(),
            request.Sorting ?? string.Empty);

        var response = itemTypes.ToPageResponse(request.Index, request.Size);
        return Ok(response);
    }
}