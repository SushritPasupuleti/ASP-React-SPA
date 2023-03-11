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
    public string Post(LocalNews localNews) 
    {
		//saves localNews to DB
        return $"Local News Posted at {DateTime.Now.ToString()}";
    }
}
