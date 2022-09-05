using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using SampleAPI.Configurations;

namespace SampleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DaprClient _daprClient;
        private readonly DaprConfiguration _config;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, DaprClient daprClient, DaprConfiguration config)
        {
            _logger = logger;
            _daprClient = daprClient;
            _config = config;   
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            _logger.LogInformation("Get weather forecast data");
            var weatherForecast = await _daprClient.GetStateAsync<WeatherForecast[]>(_config.StatestoreName,"Data");
            if (weatherForecast == null)
            {
                _logger.LogInformation("Not found in Redis");
                weatherForecast = Enumerable.Range(1, 10).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
            .ToArray();
                await _daprClient.SaveStateAsync(_config.StatestoreName, "Data", weatherForecast);

            }
            return weatherForecast;
        }
    }
}