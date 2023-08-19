using Hermes.Client.Web.Models.Error;

namespace Microsoft.AspNetCore.Mvc;

public static class ControllerExtensions
{
    public static ViewResult ErrorView(this Controller controller, ErrorViewModel model) =>
        controller.View("Views/Error/Index.cshtml", model);
}