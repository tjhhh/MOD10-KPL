using jurnalmod10_103022300065.Models;
using Microsoft.AspNetCore.Mvc;

namespace jurnalmod10_103022300065.Controllers
{
   
        [ApiController]
        [Route("api/[controller]")]
        public class MovieController : ControllerBase
        {
            private static List<Movie> daftarMovie = new List<Movie>
        {
            new Movie {Title = "The Shawshank Redemption", Director = "Frank Darabont",Stars = ["Tim Robbins","Morgan Freeman", "Bob Gunton"],Description = "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion." },
            new Movie {Title = "The Godfather ", Director = "Francis Ford Coppola ",Stars = ["Marlon Brando","Al Pacino","James Caan" ],Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." },
            new Movie {Title = "The Dark Knight", Director = "Christopher Nolan",Stars = ["Christian Bale","Heath Ledger","Aaron Eckhart" ],Description = "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness." }
            
        };

            [HttpGet]
            public ActionResult<IEnumerable<Movie>> GetMovie()
            {
                return Ok(daftarMovie);
            }

            [HttpGet("{index}")]
            public ActionResult<Movie> GetMovieByID(int index)
            {
                if (index < 0 || index >= daftarMovie.Count)
                {
                    return NotFound("Movie tidak ditemukan");
                }
                return Ok(daftarMovie[index]);
            }

            [HttpPost]
            public ActionResult<Movie> PostMovie(Movie movie)
            {
                daftarMovie.Add(movie);
                return CreatedAtAction(nameof(GetMovieByID), new { index = daftarMovie.Count - 1 }, movie);
            }

            [HttpDelete("{index}")]
            public IActionResult DeleteMovie(int index)
            {
                if (index < 0 || index >= daftarMovie.Count)
                {
                    return NotFound("Movie tidak ditemukan untuk dihapus");
                }

                daftarMovie.RemoveAt(index);
                return NoContent();
            }
        }
    
}
