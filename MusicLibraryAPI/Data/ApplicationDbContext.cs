using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MusicLibraryAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Song> Songs { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
