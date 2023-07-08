using Microsoft.EntityFrameworkCore;
using UrlShortener.Models;

namespace UrlShortener.Data
{
    public class UrlDbContext : DbContext 
    {
        public UrlDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Url> Urls { get; set; } = null!;
    }
}
