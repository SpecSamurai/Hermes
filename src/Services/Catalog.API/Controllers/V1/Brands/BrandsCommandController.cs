using Hermes.Catalog.API.Constants;
using Hermes.Catalog.API.Mappings;
using Hermes.Catalog.API.Repositories.Brands;
using Hermes.Catalog.API.Requests.Brands;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Catalog.API.Controller.V1.Brands;

[ApiController]
[EndpointGroupName(ApiSettings.ApiVersion1)]
[Tags("Brands Command")]
[Route($"{ApiSettings.ApiPrefix}/{ApiSettings.ApiVersion1}/{ApiSettings.BrandsEndpoint}")]
public class BrandsCommandController : ControllerBase
{
    private readonly IBrandQueryRepository _brandQueryRepository;
    private readonly IBrandCommandRepository _brandCommandRepository;

    public BrandsCommandController(
        IBrandQueryRepository brandQueryRepository,
        IBrandCommandRepository brandCommandRepository)
    {
        _brandQueryRepository = brandQueryRepository;
        _brandCommandRepository = brandCommandRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> CreateAsync([FromBody] BrandPostRequest request)
    {
        var brand = request.ToBrandEntity();
        await _brandCommandRepository.InsertAsync(brand, autoSave: true);

        return CreatedAtAction(nameof(CreateAsync), new { id = brand.Id }, null);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var brand = await _brandQueryRepository.FindAsync(id);

        if (brand is not null)
        {
            await _brandCommandRepository.DeleteAsync(brand, autoSave: true);
            return NoContent();
        }
        else return NotFound();
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> PatchAsync(Guid id, JsonPatchDocument<BrandPatchRequest> request)
    {
        var brand = await _brandQueryRepository.FindAsync(id);

        if (brand is not null)
        {
            var patch = brand.ToBrandPatchRequest();
            request.ApplyTo(patch);
            brand.Patch(patch);

            await _brandCommandRepository.UpdateAsync(brand, autoSave: true);
            return NoContent();
        }
        else return NotFound();
    }
}