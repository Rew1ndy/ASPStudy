using Lab2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class HomeController : Controller
    {
        private readonly CompanyService _companyService;
        private readonly MyInfoService _myInfoService;

        public HomeController(CompanyService companyService, MyInfoService myInfoService)
        {
            _companyService = companyService;
            _myInfoService = myInfoService;
        }

        public IActionResult Index()
        {
            var companyWithMostEmployees = _companyService.GetCompanyWithMostEmployees();
            ViewBag.Company = companyWithMostEmployees;
            return View();
        }

        public IActionResult MyInfo()
        {
            var myInfo = _myInfoService.GetInfo();
            ViewBag.Info = myInfo;
            return View();
        }
    }

}
