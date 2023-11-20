namespace MusicLibraryConsole.Models
{
    internal class Song
    {
        public int id { get; set; }
        public string title { get; set; }
        public string artist { get; set; }
        public string album { get; set; }
        public DateTime releaseDate { get; set; }
        public string genre { get; set; }
        public int likes { get; set; }
        public object playlistId { get; set; }
        public object playlist { get; set; }
    }
}
