using Lab9.Models;
using Microsoft.AspNetCore.Mvc;
namespace Lab9.Controllers;

public class ProductController : Controller
{
    public IActionResult Index()
    {
        var products = new List<Product>
        {
            new Product { ID = 1, Name = "Product 1", Price = 100.50m },
            new Product { ID = 2, Name = "Product 2", Price = 200.75m },
            new Product { ID = 3, Name = "Product 3", Price = 300.99m }
        };

        return View(products);
    }
}
