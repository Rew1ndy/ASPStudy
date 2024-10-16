using Lab8.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab8.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            var products = new List<Product>
            {
                new Product { ID = 1, Name = "Product 1", Price = 10.99m, CreatedDate = DateTime.Now.AddDays(-10) },
                new Product { ID = 2, Name = "Product 2", Price = 20.99m, CreatedDate = DateTime.Now.AddDays(-5) },
                new Product { ID = 3, Name = "Product 3", Price = 15.49m, CreatedDate = DateTime.Now.AddDays(-1) }
            };

            return View(products);
        }
    }
}
