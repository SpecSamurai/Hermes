using Hermes.Client.Web.Mappings;
using Hermes.Client.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Client.Web.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService accountService;

    public AccountController(IAccountService accountService)
    {
        this.accountService = accountService;
    }

    public IActionResult Index()
    {
        var accountModel = accountService.GetAccount();
        var viewModel = accountModel.ToAccountViewModel();

        return View(viewModel);
    }
}