using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Data.Models;
using Restaurant.Data.Data.Repository;

namespace Restaurant.Api.Controllers.ServiceLineController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceLineController : ControllerBase
    {
        private readonly ServiceLineRepository _serviceLineRepository;

        public ServiceLineController(Context context)
        {
            _serviceLineRepository = new ServiceLineRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _serviceLineRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var serviceLine = await _serviceLineRepository.GetById(id);
            return Ok(serviceLine);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServiceLineModel serviceLine)
        {
            await _serviceLineRepository.Add(serviceLine);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ServiceLineModel serviceLine)
        {
            await _serviceLineRepository.Update(serviceLine);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceLineRepository.RemoveById(id);
            return Ok();
        }
    }
}
