using System.Security.Policy;

namespace MusicLibraryAPI.Models
{
    public class SongUpdaterDTO
    {
        public string? Title { get; set; }
        public string? Album { get; set; }
        public string? Genre { get; set; }
        public int? Likes { get; set; }
        public DateTime? ReleaseDate { get; set; }


    }
}
