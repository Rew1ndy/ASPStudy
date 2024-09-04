using app1.Models;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("CompanyInfo")]
        public IActionResult GetCompanyInfo()
        {
            var company = new Company
            {
                Name = "Random Company",
                Address = "123 Random City.org",
                Employees = 1526
            };

            return Ok(company);
        }

        [HttpGet("RandomNumber")]
        public IActionResult GetRandomNumber()
        {
            var random = new Random();
            int number = random.Next(0, 101); // Случайное число от 0 до 100
            return Ok(number);
        }
    }
}
