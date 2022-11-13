using System.Net.Mime;
using Hermes.Catalog.API.Constants;
using Hermes.Catalog.API.Mappings;
using Hermes.Catalog.API.Repositories.Items;
using Hermes.Catalog.API.Requests;
using Hermes.Catalog.API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Catalog.API.Controller.V1.Items;

[ApiController]
[EndpointGroupName(ApiSettings.ApiVersion1)]
[Tags("Items Query")]
[Route($"{ApiSettings.ApiPrefix}/{ApiSettings.ApiVersion1}/{ApiSettings.ItemsEndpoint}")]
public class ItemsQueryController : ControllerBase
{
    private readonly IItemQueryRepository _itemQueryRepository;

    public ItemsQueryController(IItemQueryRepository itemQueryRepository) =>
        _itemQueryRepository = itemQueryRepository;

    [HttpGet("{id:guid}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ItemGetResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var item = await _itemQueryRepository.FindAsync(id);

        return item is not null
            ? Ok(item.ToItemGetResponse())
            : NotFound(item);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(PageResponse<ItemGetResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetItemsPageAsync([FromQuery] PageRequest request)
    {
        var items = await _itemQueryRepository.GetPagedListAsync(
            request.Index * request.Size,
            request.Size,
            request.Sorting ?? string.Empty);

        var response = items.ToPageResponse(request.Index, request.Size);
        return Ok(response);
    }
}