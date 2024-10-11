using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Lab7.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult DownloadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DownloadFile(string firstName, string lastName, string fileName)
        {
            string fileContent = $"Ім'я: {firstName}\nПрізвище: {lastName}";

            byte[] fileBytes = Encoding.UTF8.GetBytes(fileContent);
            return File(fileBytes, "text/plain", $"{fileName}.txt");
        }
    }
}
