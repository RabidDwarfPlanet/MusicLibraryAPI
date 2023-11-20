using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicLibraryAPI.Models;

namespace MusicLibraryAPI.Data
{
    public class SongEntityTypeConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.Property(b => b.Id).IsRequired();
            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.Artist).IsRequired();
            builder.Property(b => b.Album).IsRequired(false);
            builder.Property(b => b.ReleaseDate).IsRequired();
            builder.Property(b => b.Genre).IsRequired();
            builder.Property(b => b.Likes).IsRequired();
            builder.Property(b => b.PlaylistId).IsRequired(false);

            //Seed data
            builder.HasData(
                new Song { Id = 1, Title = "Talking to Myself", Artist = "Watsky", Album = "x Infinity", ReleaseDate = new DateTime(2016, 07, 25), Genre = "Rap", Likes = 33000 },
                new Song { Id = 2, Title = "Hit The Snooze", Artist = "The Living Tombstone", ReleaseDate = new DateTime(2022, 03, 11), Genre = "Electronic", Likes = 155000 },
                new Song { Id = 3, Title = "Overkill", Artist = "RIOT", Album = "Dogma Resistance", ReleaseDate = new DateTime(2018, 11, 05), Genre = "Electronic", Likes = 248000 },
                new Song { Id = 4, Title = "SECRET BOSS", Artist = "Camellia", Album = "Blackmagik Blazing", ReleaseDate = new DateTime(2019, 08, 31), Genre = "Electronic", Likes = 10000 },
                new Song { Id = 5, Title = "Vainilla", Artist = "ELEPS", ReleaseDate = new DateTime(2022, 08, 17), Genre = "Electronic", Likes = 1600 }
            );
        }
    }
}
