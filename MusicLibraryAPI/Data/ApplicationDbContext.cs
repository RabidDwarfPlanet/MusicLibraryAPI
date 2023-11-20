using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MusicLibraryAPI.Models;
using System.Diagnostics;

namespace MusicLibraryAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.Song> Songs { get; set; }
        public DbSet<Models.Playlist> Playlist { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new SongEntityTypeConfiguration().Configure(modelBuilder.Entity<Song>());
            new PlaylistEntityTypeConfiguration().Configure(modelBuilder.Entity<Playlist>());
        }
    }
}
