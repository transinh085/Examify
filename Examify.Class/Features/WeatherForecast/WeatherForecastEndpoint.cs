
using Examify.Core.Endpoints;

namespace Examify.Class.Features.WeatherForecast;

public class WeatherForecastEndpoint : IEndpoint
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/weatherforecast", () =>
        {
            var rng = new Random();
            var result = Enumerable.Range(1, 5).Select(index => new Domain.WeatherForecast()
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return Task.FromResult(result);
        }).WithDescription("Test api 123456");
    }
}