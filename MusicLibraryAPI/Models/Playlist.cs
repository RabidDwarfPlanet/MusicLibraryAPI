using System.ComponentModel.DataAnnotations;

namespace MusicLibraryAPI.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Song> Songs { get; set; } 
    }
}
