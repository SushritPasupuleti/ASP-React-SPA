using Microsoft.AspNetCore.Mvc;

namespace ASP_React_SPA.Controllers;

[ApiController]
// [Route("api/[controller]")]
[Route("api/local-news")]
public class LocalNewsController : ControllerBase
{
    private readonly ILogger<LocalNewsController> _logger;

    public LocalNewsController(ILogger<LocalNewsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetLocalNews")]
    public IEnumerable<LocalNews> Get()
    {
        var rng = new Random();
        return Enumerable.Range(1, 5).Select(index => new LocalNews
        {
            Title = "Local News Headline",
            Body = "Local News Content",
            Url = "Local News Url",
            PublishedAt = DateTime.Now,
            ImageUrl = "Local News Image Url"
        })
        .ToArray();
    }

    [HttpGet("{id}", Name = "GetLocalNewsById")]
    public LocalNews Get(int id)
    {
        return new LocalNews
        {
            Title = $"Local News Headline{id.ToString()}",
            Body = "Local News Content",
            Url = "Local News Url",
            PublishedAt = DateTime.Now,
            ImageUrl = "Local News Image Url"
        };
    }

    [HttpPost(Name = "PostLocalNews")]
    public IActionResult Post(LocalNews localNews)
    {
        Console.WriteLine("Saving Post with Title: " + localNews.Title);
        var newLocalNewsItem = new LocalNews
        {
            Title = localNews.Title,
            Body = localNews.Body,
            Url = localNews.Url,
            PublishedAt = localNews.PublishedAt,
            ImageUrl = localNews.ImageUrl
        };

        var result = new LocalNewsOnSave
        {
            Title = newLocalNewsItem.Title,
            PublishedAt = newLocalNewsItem.PublishedAt,
            Message = $"Local News Posted at {newLocalNewsItem.PublishedAt.ToString()}"
        };
        //saves localNews to DB
        // return $"Local News Posted at {newLocalNewsItem.PublishedAt.ToString()}";
        return Ok(result);
    }

    //maps to api/local-news/reports
    [HttpGet("reports")]
    public string GetReports()
    {
        return "Reports are ready";
    }
}
