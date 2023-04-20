using Asp.netcore_practice.Services;
using Asp.netcore_practice.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netcore_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult Add(MovieViewModel movie)
        {
            _service.Add(movie);
            return Ok();
        }

        [HttpPut("{id:int}")]

        public IActionResult Update(int id, MovieViewModel movie)
        {
            var updated=_service.Update(id, movie);
            return Ok(updated);
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var abc=_service.GetAll();
            return Ok(abc);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var content = _service.GetById(id);
                return Ok(content);
        }
    }
}
