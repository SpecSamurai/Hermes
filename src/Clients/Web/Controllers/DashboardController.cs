using Microsoft.AspNetCore.Mvc;

namespace Hermes.Client.Web.Controllers;

public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}