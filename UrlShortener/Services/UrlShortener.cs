using System.Text.RegularExpressions;
using UrlShortener.Data;
using UrlShortener.Models;

namespace UrlShortener.Services
{
    public class UrlShortener
    {
        private readonly UrlDbContext _context;

        public UrlShortener(UrlDbContext context)
        {
            _context = context;
        }

        private bool ValidateUrl(UrlDto url)
        {
            if (!Uri.TryCreate(url.Url, UriKind.Absolute, out var inputUrl))
            {
                return false;
            }
            return true;
        }

        public async Task<Url> CreateShortUrl(UrlDto url)
        {
            if (!ValidateUrl(url)) {
                return null;
            }
            var rand = new Random();
            string safeUrl = string.Empty;
            Enumerable.Range(48, 75)
              .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
              .OrderBy(o => new Random().Next())
              .ToList()
              .ForEach(i => safeUrl += Convert.ToChar(i));
            string newUrl = safeUrl.Substring(rand.Next(0, safeUrl.Length),rand.Next(4,8));
            var sUrl = new Url()
            {
                originUrl = url.Url,
                shortUrl = newUrl
            };
            _context.Urls.Add(sUrl);
            await _context.SaveChangesAsync();
            return sUrl;

        }
    }
}
