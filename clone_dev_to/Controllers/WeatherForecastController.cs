using clone_dev_to.Data;
using clone_dev_to.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace clone_dev_to.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly BloggerContext _ctx;
    
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching","Scorchingasdf"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,BloggerContext ctx)
    {
        _ctx = ctx;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        // var tags = _ctx.Tags.ToList();
        // Console.WriteLine(tags);
        // foreach (var tag in tags)
        // {
        //     Console.WriteLine(tag.Id);
        //     Console.WriteLine(tag.Name);
        // }
        //
        // _ctx.Posts.Add(new PostModel
        // {
        //     Title = "React 101",
        //     Detail = "aspdofnsdadvnaspdnsadlkfnasldkfnaskd;fnas;dlkf",
        //     PublicationDate = DateTime.UtcNow,
        //     Tags = tags
        // });
        // _ctx.SaveChanges();
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}
