using Microsoft.AspNetCore.Mvc;
using MusicLibraryAPI.Data;

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
                song = updatedSong;
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
    }
}
