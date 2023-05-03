using Asp.netcore_practice.Services;
using Asp.netcore_practice.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Asp.netcore_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
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
            return Ok(movie);
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
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var abc=_service.GetAll();
            return Ok(abc);

        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var content = _service.GetById(id);
                return Ok(content);
        }
    }
}
