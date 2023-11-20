using Microsoft.AspNetCore.Mvc;
using MusicLibraryAPI.Data;
using MusicLibraryAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PlaylistsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<PlaylistsController>
        [HttpGet]
        public IActionResult Get()
        {
            var playlist = _context.Playlist.ToList();
            return Ok(playlist);
        }

        // GET api/<PlaylistsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var playlist = _context.Playlist.Where(p => p.Id == id).SingleOrDefault();
            if (playlist == null) { return NotFound(); }
            else { return Ok(playlist); }

        }

        // POST api/<PlaylistsController>
        [HttpPost]
        public IActionResult Post([FromBody] Models.Playlist playlist)
        {
            _context.Playlist.Add(playlist);
            _context.SaveChanges();
            return StatusCode(201, playlist);
        }

        // PUT api/<PlaylistsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Models.Playlist updatedPlaylist)
        {
            var playlist = _context.Playlist.Where(p => p.Id == id).SingleOrDefault();
            if (playlist == null) { return NotFound(); }
            else
            {
                playlist = updatedPlaylist;
                _context.Playlist.Update(playlist);
                _context.SaveChanges();
                return Ok(playlist);
            }
        }

        // DELETE api/<PlaylistsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var playlist = _context.Playlist.Where(p => p.Id == id).SingleOrDefault();
            if (playlist != null)
            {
                _context.Playlist.Remove(playlist);
                _context.SaveChanges();
                return NoContent();
            }
            else { return NotFound(); }
        }

        [HttpPatch("{playlistId}/{songId}")]
        public IActionResult Patch(int playlistId, int songID)
        {
            SongToPlaylistDTO playlist = new SongToPlaylistDTO();
            playlist.playlistId = playlistId;
            var song = _context.Songs.Where(s => s.Id == songID).SingleOrDefault();
            if (song == null || playlist == null) { return NotFound(); }
            else
            {
                song.PlaylistId = playlist.playlistId;
                _context.Songs.Update(song);
                _context.SaveChanges();
                return Ok(song);
            }
        }
    }
}
