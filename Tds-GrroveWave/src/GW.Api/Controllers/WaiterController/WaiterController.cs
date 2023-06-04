using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Data.Models;
using Restaurant.Data.Data.Repository;

namespace Restaurant.Api.Controllers.WaiterController
{
    [ApiController]
    [Route("api/[controller]")]
    public class WaiterController : ControllerBase
    {
        private readonly WaiterRepository _waiterRepository;

        public WaiterController(Context context)
        {
            _waiterRepository = new WaiterRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _waiterRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var waiter = await _waiterRepository.GetById(id);
            return Ok(waiter);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WaiterModel waiter)
        {
            await _waiterRepository.Add(waiter);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] WaiterModel waiter)
        {
            await _waiterRepository.Update(waiter);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _waiterRepository.RemoveById(id);
            return Ok();
        }
    }
}
