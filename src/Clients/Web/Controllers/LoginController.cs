using Microsoft.AspNetCore.Mvc;

namespace Hermes.Client.Web.Controllers;

public class LoginController : Controller
{
    public IActionResult Index() =>
        View();
}