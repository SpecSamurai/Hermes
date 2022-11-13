using System.Net.Mime;
using Hermes.Catalog.API.Constants;
using Hermes.Catalog.API.Mappings;
using Hermes.Catalog.API.Repositories.ItemTypes;
using Hermes.Catalog.API.Requests;
using Hermes.Catalog.API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Catalog.API.Controller.V1.Brands;

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
    [ProducesResponseType(typeof(BrandGetResponse), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(PageResponse<BrandGetResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetItemsPageAsync([FromQuery] PageRequest request)
    {
        var itemTypes = await _itemTypeQueryRepository.GetPagedListAsync(
            request.Index * request.Size,
            request.Size,
            request.Sorting ?? string.Empty);

        var response = itemTypes.ToPageResponse(request.Index, request.Size);
        return Ok(response);
    }
}