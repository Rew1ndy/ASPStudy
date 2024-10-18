using Lab10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab10.Controllers
{
    public class ConsultationController : Controller
    {
        private static readonly List<string> products = new List<string> { "JavaScript", "C#", "Java", "Python", "Основи" };
        
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Products = new SelectList(products);
            return View();
        }

        [HttpPost]
        public IActionResult Register(ConsultationRequest request)
        {
            if (ModelState.IsValid)
            {
                if (request.Product == "Основи" && request.DesiredDate.DayOfWeek == DayOfWeek.Monday)
                {
                    ModelState.AddModelError("Product", "Консультації по «Основи» не можуть проводитися в понеділок.");
                }

                if (ModelState.IsValid)
                {
                    return RedirectToAction("Success");
                }
            }

            ViewBag.Products = new SelectList(products);
            return View(request);
        }

        public IActionResult Success()
        {
            return View();
        }
    }

}
