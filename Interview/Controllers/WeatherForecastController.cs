using Microsoft.AspNetCore.Mvc;
using DecoratorExample1 = Interview.Core.Decorator.Main;
using ObserverExample1 = Interview.Core.Observer.Main;

namespace Interview.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public string[] Get()
    {
        DecoratorExample1.Execute();
        ObserverExample1.Execute();
        return Summaries;
    }
}
