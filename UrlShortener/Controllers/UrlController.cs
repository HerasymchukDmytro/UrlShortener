using Microsoft.AspNetCore.Mvc;
using UrlShortener.Models;
using UrlShortener.Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UrlShortener.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly Services.UrlShortener _shortener;

        public UrlController(Services.UrlShortener shortener)
        {
            _shortener = shortener;
        }

        [HttpPost]
        public IActionResult Post([FromBody] UrlDto url)
        {
            Url sUrl = _shortener.CreateShortUrl(url).Result;
            var result = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/{sUrl.shortUrl}";
            UrlDto resultUrl = new UrlDto()
            {
                Url = result
            };
            return Ok(resultUrl);
        }

        
    }
}
