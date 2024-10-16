using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class WeatherController : Controller
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<IActionResult> Index(string region = "Mykolaiv")
    {
        var weatherInfo = await _weatherService.GetWeatherAsync(region);
        ViewBag.WeatherInfo = weatherInfo;
        ViewBag.Region = region;
        return View();
    }
}
