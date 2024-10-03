using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class FormController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(string userValue, DateTime expirationDate)
        {
            Console.WriteLine("Receive httpPost");
            // Установка куки с значением и временем истечения
            CookieOptions options = new CookieOptions
            {
                Expires = expirationDate
            };
            Response.Cookies.Append("userValue", userValue, options);

            return RedirectToAction("CheckCookie");
        }

        [HttpGet]
        public IActionResult CheckCookie()
        {
            if (Request.Cookies.TryGetValue("userValue", out string userValue))
            {
                ViewBag.CookieValue = userValue;
            }
            else
            {
                ViewBag.CookieValue = "Cookie not found or expired.";
            }

            return View();
        }
    }
}
