using Microsoft.AspNetCore.Mvc;

namespace Hermes.Client.Web.Controllers;

public class CatalogController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}