using Lab6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab6.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user.Age < 16)
            {
                return View("AgeRestriction");
            }

            return RedirectToAction("OrderQuantity");
        }

        [HttpGet]
        public IActionResult OrderQuantity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderQuantity(int quantity)
        {
            if (quantity < 0)
            {
                ModelState.AddModelError("", "Quantity must be a non-negative integer.");
                return View();
            }

            return RedirectToAction("OrderDetails", new { quantity });
        }

        [HttpGet]
        public IActionResult OrderDetails(int quantity)
        {
            var products = new List<Product>();
            for (int i = 0; i < quantity; i++)
            {
                products.Add(new Product());
            }

            return View(products);
        }

        [HttpPost]
        public IActionResult OrderDetails(List<Product> products)
        {
            return View("OrderSummary", products);
        }
    }
}
