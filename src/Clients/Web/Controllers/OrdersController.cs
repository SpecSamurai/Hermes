using Hermes.Client.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Client.Web.Controllers;

public class OrdersController : Controller
{
    public IActionResult Index()
    {
        return View(new OrdersViewModel
        {
            Orders = new List<OrderViewModel>
            {
                new OrderViewModel
                {
                    Id = Guid.NewGuid(),
                    Products = new List<OrderedProductViewModel>
                    {
                        new OrderedProductViewModel
                        {
                            Name = "Product 1"
                        },
                        new OrderedProductViewModel
                        {
                            Name = "Product 2"
                        },
                        new OrderedProductViewModel
                        {
                            Name = "Product 3"
                        }
                    },
                    Price = 100,
                    Date = DateTime.Now,
                    Status = "Paid"
                }
            }
        });
    }
}