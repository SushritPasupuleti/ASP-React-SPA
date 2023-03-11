namespace ASP_React_SPA;

public class LocalNews
{
    public string? Title { get; set; }
    public string? Body { get; set; }
    public string? Url { get; set; }
    public string? ImageUrl { get; set; }
    public DateTime PublishedAt { get; set; }
}

public class LocalNewsOnSave
{
	public string? Message { get; set; }
	public string? Title { get; set; }
	public DateTime PublishedAt { get; set; }
}
