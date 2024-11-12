using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Lab12.Controllers
{
    public class UserDBController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
