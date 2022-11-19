using System.Net.Mime;
using Hermes.Catalog.API.Constants;
using Hermes.Catalog.API.Mappings;
using Hermes.Catalog.API.Repositories.Brands;
using Hermes.Catalog.API.Requests;
using Hermes.Catalog.API.Responses;
using Hermes.Frameworks.Repositories.DataStructures;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Catalog.API.Controller.V1.Brands;

[ApiController]
[EndpointGroupName(ApiSettings.ApiVersion1)]
[Tags("Brands Query")]
[Route($"{ApiSettings.ApiPrefix}/{ApiSettings.ApiVersion1}/{ApiSettings.BrandsEndpoint}")]
public class BrandsQueryController : ControllerBase
{
    private readonly IBrandQueryRepository _brandQueryRepository;

    public BrandsQueryController(IBrandQueryRepository brandQueryRepository) =>
        _brandQueryRepository = brandQueryRepository;

    [HttpGet("{id:guid}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BrandGetResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var brand = await _brandQueryRepository.FindAsync(id);

        return brand is not null
            ? Ok(brand.ToBrandGetResponse())
            : NotFound(brand);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(PageResponse<BrandGetResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPageAsync([FromQuery] PageRequest request)
    {
        var brands = await _brandQueryRepository.GetPageAsync(
            Offset.Of(request.Index, request.Size),
            entity => entity.ToBrandGetResponse(),
            request.Sorting ?? string.Empty);

        var response = brands.ToPageResponse(request.Index, request.Size);
        return Ok(response);
    }
}