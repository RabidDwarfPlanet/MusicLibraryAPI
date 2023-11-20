using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibraryAPI.Models;

namespace MusicLibraryAPI.Data
{
    public class PlaylistEntityTypeConfiguration : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Name).IsRequired();


            //Seed data
            builder.HasData(
                new Playlist { Id = 1, Name = "EDM" },
                new Playlist { Id = 2, Name = "Lyrical" }
            );
        }
    }
}
