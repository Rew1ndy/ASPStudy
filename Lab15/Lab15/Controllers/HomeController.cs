using Lab15.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Diagnostics;
using System.Net.Mail;

namespace Lab15.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IEmailSender _emailSender;

        public HomeController(ILogger<HomeController> logger/*, IEmailSender emailSender*/)
        {
            _logger = logger;
            //this._emailSender = emailSender;
        }

        public IActionResult Index()
        {
            //await _emailSender.SendEmailAsync("cimopi5300@inikale.com", "Test", "Hello World!");
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse("willis.wiza18@ethereal.email"));
            //email.To.Add(MailboxAddress.Parse("willis.wiza18@ethereal.email"));
            //email.Subject = "Test Email";
            //email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "Hi Mark" };

            //using var smtp = new MailKit.Net.Smtp.SmtpClient();
            //smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            //smtp.Authenticate("willis.wiza18@ethereal.email", "J4Bvk1dhrqNChegfe9");
            //smtp.Send(email);
            //smtp.Disconnect(true);


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
