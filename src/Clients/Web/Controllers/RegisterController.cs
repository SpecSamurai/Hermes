using Microsoft.AspNetCore.Mvc;

namespace Hermes.Client.Web.Controllers;

public class RegisterController : Controller
{
    public IActionResult Index() =>
        View();
}