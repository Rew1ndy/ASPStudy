using Lab14.Models;
using Microsoft.AspNetCore.Mvc;
using OpenTelemetry.Trace;
using System.Diagnostics;

namespace Lab14.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherService _weatherService;
        private static readonly ActivitySource ActivitySource = new("OpenTelemetryApp");

        public HomeController(WeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<IActionResult> Index(string region = "Mykolaiv")
        {
            using var activity = ActivitySource.StartActivity("GetWeather", ActivityKind.Server);
            activity?.SetTag("region", region);
            activity?.SetTag("custom.attribute", "weather_forecast");

            try
            {
                var weatherInfo = await _weatherService.GetWeatherAsync(region);

                activity?.SetTag("weatherInfoRetrieved", !string.IsNullOrEmpty(weatherInfo));
                activity?.SetTag("status_code", 200);
                ViewBag.WeatherInfo = weatherInfo;
                ViewBag.Region = region;

                return View();
            }
            catch (Exception ex)
            {
                activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                activity?.SetTag("status_code", 500);
                throw;
            }
        }
    }
}
