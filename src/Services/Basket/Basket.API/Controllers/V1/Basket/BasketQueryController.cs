using System.Net.Mime;
using Hermes.Basket.API.Constants;
using Hermes.Basket.API.Mappings;
using Hermes.Basket.API.Repositories;
using Hermes.Basket.API.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Basket.API.Controller.V1.Basket;

[ApiController]
[EndpointGroupName(ApiSettings.ApiVersion1)]
[Tags("Basket Query")]
[Route($"{ApiSettings.ApiPrefix}/{ApiSettings.ApiVersion1}/{ApiSettings.BasketEndpoint}")]
public class BrandsQueryController : ControllerBase
{
    private readonly IBasketQueryRepository _basketQueryRepository;

    public BrandsQueryController(IBasketQueryRepository basketQueryRepository) =>
        _basketQueryRepository = basketQueryRepository;

    [HttpGet("{customerId:guid}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(CustomerBasketGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync(Guid customerId)
    {
        var basket = await _basketQueryRepository.FindAsync(customerId);

        return basket is not null
            ? Ok(basket.ToCustomerBasketGetResponse())
            : NotFound();
    }
}