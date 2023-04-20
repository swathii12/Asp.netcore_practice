using Asp.netcore_practice.Services;
using Asp.netcore_practice.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netcore_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController:ControllerBase
    {
        private readonly IActorService _service;

        public ActorController(IActorService service)
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
        public IActionResult AddActor(ActorViewModel actor)
        {
            _service.AddActor(actor);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpPut("{id:int}")]

        public IActionResult Update(int id, ActorViewModel actor)
        {
            var updated = _service.Update(id, actor);
            return Ok(updated);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var getAll = _service.GetAllActors();
            return Ok(getAll);

        }
    }
}
