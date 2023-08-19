using Microsoft.AspNetCore.Mvc;
using Hermes.Client.Web.Models.Error;

namespace Hermes.Client.Web.Controllers;

[Route("{controller}")]
public class ErrorController : Controller
{
    [Route("{code}")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Index(string code) =>
        View(new ErrorViewModel { StatusCode = code });
}