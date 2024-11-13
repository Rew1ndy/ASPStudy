using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey = "009bb6c2b805a334059dcaa734620703";
    private readonly ActivitySource _activitySource;

    public WeatherService(HttpClient httpClient, ActivitySource activitySource)
    {
        _httpClient = httpClient;
        _activitySource = activitySource;
    }

    public async Task<string> GetWeatherAsync(string region)
    {
        using var activity = _activitySource.StartActivity("GetWeatherData", ActivityKind.Client);
        activity?.SetTag("region", region);

        string url = $"https://api.openweathermap.org/data/2.5/weather?q={region}&appid={_apiKey}&units=metric";
        var response = await _httpClient.GetFromJsonAsync<WeatherResponse>(url);

        if (response != null)
        {
            activity?.SetTag("temperature", response.Main.Temp);
            activity?.SetTag("description", response.Weather[0].Description);

            return $"Температура: {response.Main.Temp}°C, Опис: {response.Weather[0].Description}";
        }
        else
        {
            activity?.SetTag("error", "Weather information is not available");
            return "Інформація про погоду недоступна";
        }
    }
}

public class WeatherResponse
{
    public Main Main { get; set; }
    public Weather[] Weather { get; set; }
}

public class Main
{
    public float Temp { get; set; }
}

public class Weather
{
    public string Description { get; set; }
}
