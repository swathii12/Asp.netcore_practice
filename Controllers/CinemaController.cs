using Asp.netcore_practice.Services;
using Asp.netcore_practice.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netcore_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaController:ControllerBase
    {
        private readonly ICinemaService _service;

        public CinemaController(ICinemaService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var response = _service.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddCinema(CinemaViewModel cinema)
        {
            _service.AddCinema(cinema);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpPut("{id:int}")]

        public IActionResult Update(int id, CinemaViewModel cinema)
        {
            var updated = _service.Update(id, cinema);
            return Ok(updated);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var getAll = _service.GetAllCinemas();
            return Ok(getAll);

        }
    }
}
