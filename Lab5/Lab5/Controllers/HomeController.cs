using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Content("<html><body><h2>Submit Form</h2>" +
                "<form method='post' action='/Home/SubmitForm'>" +
                "<label for='userValue'>Value:</label>" +
                "<input type='text' id='userValue' name='userValue' required /><br /><br />" +
                "<label for='expirationDate'>Expiration Date:</label>" +
                "<input type='datetime-local' id='expirationDate' name='expirationDate' required /><br /><br />" +
                "<button type='submit'>Submit</button></form>" +
                "</body></html>", "text/html");
        }

        [HttpPost("SubmitForm")]
        public IActionResult SubmitForm([FromForm] string userValue, [FromForm] DateTime expirationDate)
        {
            Console.WriteLine("Received POST request");

            // Установка куки с значением и временем истечения
            var options = new CookieOptions
            {
                Expires = expirationDate
            };
            Response.Cookies.Append("userValue", userValue, options);

            return Redirect("/Home/CheckCookie");
        }

        [HttpGet("CheckCookie")]
        public IActionResult CheckCookie()
        {
            if (Request.Cookies.TryGetValue("userValue", out string userValue))
            {
                return Content($"<html><body><h2>Cookie Value: {userValue}</h2></body></html>", "text/html");
            }
            else
            {
                return Content("<html><body><h2>Cookie not found or expired.</h2></body></html>", "text/html");
            }
        }
    }
}
