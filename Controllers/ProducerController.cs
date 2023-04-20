using Asp.netcore_practice.Services;
using Asp.netcore_practice.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Asp.netcore_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController:ControllerBase
    {
        private readonly IProducerService _service;

        public ProducerController(IProducerService service)
        {
            _service = service;
        }


        [HttpPost]
        public IActionResult Add(ProducerViewModel producer)
        {
            _service.AddProducer(producer);
            return Ok();
        }

        [HttpPut("{id:int}")]

        public IActionResult Update(int id, ProducerViewModel producer)
        {
            var updated = _service.Update(id, producer);
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
            var getAll = _service.GetAllProducers();
            return Ok(getAll);

        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var content = _service.GetById(id);
            return Ok(content);
        }
    }
}
