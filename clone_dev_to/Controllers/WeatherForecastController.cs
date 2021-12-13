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
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        "Scorchingasdf"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, BloggerContext ctx)
    {
        _ctx = ctx;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        // var postAndTags = _ctx.Posts
        //     .Include(p => p.Tags)
        //     .Include(p => p.User)
        //     .OrderByDescending(p => p.PublicationDate).ToList();
        //
        // var result = postAndTags.Select(p => new Content
        // {
        //     UserId = p.UserId,
        //     FullName = p.User.FullName,
        //     PublicationDate = p.PublicationDate,
        //     BlogId = p.Id,
        //     BlogTitle = p.Title,
        //     BlogDetail = p.Detail,
        //     BlogTags = p.Tags.Select(t => new Tag{Id = t.Id,Name = t.Name}).ToList()
        // }).ToList();
        
        
        return Ok("result");
    }
}