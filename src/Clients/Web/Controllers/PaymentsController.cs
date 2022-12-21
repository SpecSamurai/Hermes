using Hermes.Client.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Client.Web.Controllers;

public class PaymentsController : Controller
{
    public IActionResult Index()
    {
        return View(new PaymentsViewModel
        {
            Payments = new List<PaymentViewModel>
            {
                new PaymentViewModel
                {
                    Id = Guid.NewGuid(),
                    OrderId = Guid.NewGuid(),
                    Price = 100,
                    Date = DateTime.Now,
                    Status = "Paid"
                },
                new PaymentViewModel
                {
                    Id = Guid.NewGuid(),
                    OrderId = Guid.NewGuid(),
                    Price = 100,
                    Date = DateTime.Now,
                    Status = "Paid"
                },
                new PaymentViewModel
                {
                    Id = Guid.NewGuid(),
                    OrderId = Guid.NewGuid(),
                    Price = 100,
                    Date = DateTime.Now,
                    Status = "Paid"
                },
            }
        });
    }
}