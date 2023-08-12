using Hermes.Client.Web.Configurations;
using Hermes.Client.Web.Constants;
using Hermes.Client.Web.Mappings;
using Hermes.Client.Web.Options;
using Hermes.Client.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Hermes.Client.Web.Controllers;

public class PaymentsController : Controller
{
    private readonly PaginationOptions paginationOptions;
    private readonly IPaymentsService paymentsService;

    public PaymentsController(
        IOptions<PaginationOptions> paginationOptions,
        IPaymentsService paymentsService)
    {
        this.paginationOptions = paginationOptions.Value;
        this.paymentsService = paymentsService;
    }

    public async Task<IActionResult> Index([FromQuery] int pageIndex)
    {
        var result = await paymentsService.GetPageAsync(pageIndex);
        var viewConfig = new PaginationViewConfiguration
        {
            MaxAdditionalPages = paginationOptions.MaxAdditionalPages,
            PageUrl = $"?{nameof(pageIndex)}={{0}}"
        };

        return result.Match(
            page => View(page.ToPaymentsViewModel(viewConfig)),
            failure => View(Views.Error, failure.ToErrorViewModel()));
    }
}