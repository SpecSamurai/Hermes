using Hermes.Client.Web.Configurations;
using Hermes.Client.Web.Mappings;
using Hermes.Client.Web.Options;
using Hermes.Client.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Hermes.Client.Web.Controllers;

public class CatalogController : Controller
{
    private readonly BasketApiOptions basketApiOptions;
    private readonly PaginationOptions paginationOptions;
    private readonly ICatalogService catalogService;

    public CatalogController(
        IOptions<BasketApiOptions> basketApiOptions,
        IOptions<PaginationOptions> paginationOptions,
        ICatalogService catalogService)
    {
        this.basketApiOptions = basketApiOptions.Value;
        this.paginationOptions = paginationOptions.Value;
        this.catalogService = catalogService;
    }

    public async Task<IActionResult> Index([FromQuery] int pageIndex)
    {
        var result = await catalogService.GetPageAsync(pageIndex);
        var viewConfig = new PaginationViewConfiguration
        {
            MaxAdditionalPages = paginationOptions.MaxAdditionalPages,
            PageUrl = $"?{nameof(pageIndex)}={{0}}"
        };

        return result.Match(
            page => View(page.ToCatalogViewModel(viewConfig, basketApiOptions)),
            failure => this.ErrorView(failure.ToErrorViewModel()));
    }
}