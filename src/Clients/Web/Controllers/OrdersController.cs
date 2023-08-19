using Hermes.Client.Web.Configurations;
using Hermes.Client.Web.Mappings;
using Hermes.Client.Web.Options;
using Hermes.Client.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Hermes.Client.Web.Controllers;

public class OrdersController : Controller
{
    private readonly PaginationOptions paginationOptions;
    private readonly IOrdersService ordersService;

    public OrdersController(
        IOptions<PaginationOptions> paginationOptions,
        IOrdersService ordersService)
    {
        this.paginationOptions = paginationOptions.Value;
        this.ordersService = ordersService;
    }

    public async Task<IActionResult> Index([FromQuery] int pageIndex)
    {
        var result = await ordersService.GetPageAsync(pageIndex);
        var viewConfig = new PaginationViewConfiguration
        {
            MaxAdditionalPages = paginationOptions.MaxAdditionalPages,
            PageUrl = $"?{nameof(pageIndex)}={{0}}"
        };

        return result.Match(
            page => View(page.ToOrdersViewModel(viewConfig)),
            failure => this.ErrorView(failure.ToErrorViewModel()));
    }
}