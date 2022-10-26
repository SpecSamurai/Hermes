using System.Net.Mime;
using Hermes.Catalog.API.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Catalog.API.Controller.V2;

[ApiController]
[ApiExplorerSettings(GroupName = ApiSettings.ApiVersion2)]
[Route($"api/{ApiSettings.ApiVersion2}/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ILogger<ItemsController> _logger;

    public ItemsController(ILogger<ItemsController> logger) =>
        _logger = logger;

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(IEnumerable<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(500)]
    public string Get() =>
        typeof(ItemsController).FullName ?? string.Empty;
}