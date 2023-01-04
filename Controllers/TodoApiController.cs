namespace TodoApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using TodoApi.Tracing;

[ApiController]
[Route("[controller]")]
public class TodoApiController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<TodoApiController> _logger;
    private readonly TracerFactory _tracerFactory;
    public TodoApiController(ILogger<TodoApiController> logger, TracerFactory tracerFactory)
    {
        _logger = logger;
        _tracerFactory = tracerFactory;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var tracer = _tracerFactory.GetTracer("GetWeatherForecast", "test");
        tracer.Log("GetWeatherForecast in test");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
