using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Data.Models;
using Restaurant.Data.Data.Repository;

namespace Restaurant.Api.Controllers.ServiceController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ServiceRepository _serviceRepository;

        public ServiceController(Context context)
        {
            _serviceRepository = new ServiceRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var services = await _serviceRepository.GetAll();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var service = await _serviceRepository.GetById(id);
            return Ok(service);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServiceModel service)
        {
            var response = await _serviceRepository.Add(service);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ServiceModel service)
        {
            await _serviceRepository.Update(service);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _serviceRepository.RemoveById(id);
            return Ok();
        }
    }
}
