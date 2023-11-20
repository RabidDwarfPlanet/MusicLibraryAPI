using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibraryConsole.Models
{
    public class SongUpdaterDTO
    {
        public string? Title { get; set; }
        public string? Artist { get; set; }
        public string? Album { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public int? Likes { get; set; }
    }
}
