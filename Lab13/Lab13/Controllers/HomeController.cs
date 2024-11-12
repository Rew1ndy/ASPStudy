using Lab13.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Diagnostics;

namespace Lab13.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var user = User.Identity.Name;

            Log.Information("User on home page.", user);
            return View();
        }

        public IActionResult Error()
        {
            try
            {
                throw new Exception("Some unexpected error.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "We have error in error");
                return View("Error");
            }
        }

        public IActionResult TestLogging()
        {
            Log.Debug("Log of Debug level."); 
            Log.Information("Information log.");
            Log.Warning("Warning log."); 
            Log.Error("Error log."); 
            Log.Fatal("Fatal error log."); 
            return Content("Logs has been writen.");
        }
    }
}
