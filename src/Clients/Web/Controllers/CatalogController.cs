using Hermes.Client.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hermes.Client.Web.Controllers;

public class CatalogController : Controller
{
    public IActionResult Index()
    {
        return View(new CatalogViewModel
        {
            Products = new List<ProductViewModel>
            {
                new ProductViewModel
                {
                    Name = "Shirt 1",
                    Description = "Blue Denim Shirt",
                    PictureUri = @"https://via.placeholder.com/200",
                    Brand = "Brand 1",
                    Price = 10
                },
                new ProductViewModel
                {
                    Name = "Shirt 2",
                    Description = "Blue Denim Shirt",
                    PictureUri = @"https://via.placeholder.com/200",
                    Brand = "Brand 2",
                    Price = 12
                },
                new ProductViewModel
                {
                    Name = "Shirt 3",
                    Description = "Blue Denim Shirt",
                    PictureUri = @"https://via.placeholder.com/200",
                    Brand = "Brand 3",
                    Price = 10
                },
                new ProductViewModel
                {
                    Name = "Shirt 4",
                    Description = "Blue Denim Shirt",
                    PictureUri = @"https://via.placeholder.com/200",
                    Brand = "Brand 4",
                    Price = 9
                },
                new ProductViewModel
                {
                    Name = "Shirt 5",
                    Description = "Blue Denim Shirt",
                    PictureUri = @"https://via.placeholder.com/200",
                    Brand = "Brand 5",
                    Price = 13
                },
            }
        });
    }
}