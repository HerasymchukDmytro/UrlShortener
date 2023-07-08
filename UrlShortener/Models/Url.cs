namespace UrlShortener.Models
{
    public class Url
    {
        public int Id { get; set; }
        public string shortUrl { get; set; } = string.Empty;
        public string originUrl { get; set; } = string.Empty;

    }
}
