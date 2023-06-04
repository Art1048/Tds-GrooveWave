using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Data.Models;
using Restaurant.Data.Data.Repository;

namespace Restaurant.Api.Controllers.TableController
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        private readonly TableRepository _tableRepository;

        public TableController(Context context)
        {
            _tableRepository = new TableRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tables = await _tableRepository.GetAll();
            return Ok(tables);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var table = await _tableRepository.GetById(id);
            return Ok(table);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TableModel table)
        {
            await _tableRepository.Add(table);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TableModel table)
        {
            await _tableRepository.Update(table);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine(id);
            await _tableRepository.RemoveById(id);
            return Ok();
        }
    }
}
