using Hermes.Basket.API.Constants;
using Hermes.Basket.API.Mappings;
using Hermes.Basket.API.Repositories;
using Hermes.Basket.API.Requests;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Basket.API.Controller.V1.Basket;

[ApiController]
[EndpointGroupName(ApiSettings.ApiVersion1)]
[Tags("Basket Command")]
[Route($"{ApiSettings.ApiPrefix}/{ApiSettings.ApiVersion1}/{ApiSettings.BasketEndpoint}")]
public class BasketCommandController : ControllerBase
{
    private readonly IBasketQueryRepository _basketQueryRepository;
    private readonly IBasketCommandRepository _basketCommandRepository;

    public BasketCommandController(
        IBasketQueryRepository basketQueryRepository,
        IBasketCommandRepository basketCommandRepository)
    {
        _basketQueryRepository = basketQueryRepository;
        _basketCommandRepository = basketCommandRepository;
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await _basketCommandRepository.DeleteAsync(id);
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> PostAsync(CustomerBasketPostRequest request)
    {
        var entity = request.ToCustomerBasket();
        await _basketCommandRepository.UpdateAsync(entity);

        return Created($"/{ApiSettings.ApiPrefix}/{ApiSettings.ApiVersion1}/{ApiSettings.BasketEndpoint}/{entity.Id}", entity.Id);
    }

    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> PatchAsync(Guid id, JsonPatchDocument<CustomerBasketPatchRequest> request)
    {
        var basket = await _basketQueryRepository.FindAsync(id);

        if (basket is not null)
        {
            var patch = basket.ToCustomerBasketPatchRequest();
            request.ApplyTo(patch);
            basket.Patch(patch);

            await _basketCommandRepository.UpdateAsync(basket);
            return NoContent();
        }
        else return NotFound();
    }
}