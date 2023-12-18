using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MusicLibraryAPI.Data;
using MusicLibraryAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SongsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<SongController>
        [HttpGet]
        public IActionResult Get()
        {
            var songs = _context.Songs.ToList();
            return Ok(songs);
        }

        // GET api/<SongController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var song = _context.Songs.Where(s => s.Id == id).SingleOrDefault();
            if (song == null) { return NotFound(); }
            else { return Ok(song); }

        }

        // POST api/<SongController>
        [HttpPost]
        public IActionResult Post([FromBody] Models.Song song)
        {
            _context.Songs.Add(song);
            _context.SaveChanges();
            return StatusCode(201, song);
        }

        // PUT api/<SongController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Models.Song updatedSong)
        {
            var song = _context.Songs.Where(s => s.Id == id).SingleOrDefault();
            if (song == null) { return NotFound(); }
            else
            {
                song.Title = updatedSong.Title;
                song.Artist = updatedSong.Artist;
                song.Album = updatedSong.Album;
                song.ReleaseDate = updatedSong.ReleaseDate;
                song.Genre = updatedSong.Genre;
                song.Likes = updatedSong.Likes;
                _context.Songs.Update(song);
                _context.SaveChanges();
                return Ok(song);
            }
        }

        // DELETE api/<SongController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var song = _context.Songs.Where(s => s.Id == id).SingleOrDefault();
            if(song != null)
            {
                _context.Songs.Remove(song);
                _context.SaveChanges();
                return NoContent();
            }
            else { return NotFound(); }
        }

        // PUT api/<SongController>/5
        [HttpPut("likes/{id}")]
        public IActionResult Like(int id)
        {
            var song = _context.Songs.Where(s => s.Id == id).SingleOrDefault();
            if (song == null) { return NotFound(); }
            else
            {
                song.Likes++;
                _context.Songs.Update(song);
                _context.SaveChanges();
                return Ok(song);
            }
        }

        // PUT api/<SongController>/5
        [HttpPut("dislikes/{id}")]
        public IActionResult Dislike(int id)
        {
            var song = _context.Songs.Where(s => s.Id == id).SingleOrDefault();
            if (song == null) { return NotFound(); }
            else
            {
                song.Likes--;
                _context.Songs.Update(song);
                _context.SaveChanges();
                return Ok(song);
            }
        }

        ////PATCH api/<SongController>/5
        //[HttpPatch("{id}")]
        //public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Song> patchDocument)
        //{
        //    var song = _context.Songs.Where(s => s.Id == id).SingleOrDefault();
        //    if (song == null) { return NotFound(); }
        //    else
        //    {
        //        patchDocument.ApplyTo(song, ModelState);
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        _context.Songs.Update(song);
        //        _context.SaveChanges();
        //        return Ok(song);
        //    }
        //}

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] SongUpdaterDTO songUpdaterDTO)
        {
            var song = _context.Songs.Where(s => s.Id == id).SingleOrDefault();
            if (song == null) { return NotFound(); }
            else
            {

                if(songUpdaterDTO.Title != null) { song.Title = songUpdaterDTO.Title; }
                if (songUpdaterDTO.Genre != null) { song.Genre = songUpdaterDTO.Genre; }
                if (songUpdaterDTO.Album != null) { song.Album = songUpdaterDTO.Album; }
                if (songUpdaterDTO.Likes != null) { song.Likes = (int)songUpdaterDTO.Likes; }
                if (songUpdaterDTO.ReleaseDate != null) { song.ReleaseDate = (DateTime)songUpdaterDTO.ReleaseDate; }
                _context.Songs.Update(song);
                _context.SaveChanges();
                return Ok(song);
            }
        }


    }
}
