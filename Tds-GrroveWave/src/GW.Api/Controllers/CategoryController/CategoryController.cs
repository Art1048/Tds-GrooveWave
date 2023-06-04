using Microsoft.AspNetCore.Mvc;
using Restaurant.Data.Data.Models;
using Restaurant.Data.Data.Repository;

namespace Restaurant.Api.Controllers.CategoryController
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryController(Context context)
        {
            _categoryRepository = new CategoryRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryRepository.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryRepository.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryModel category)
        {
            await _categoryRepository.Add(category);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoryModel category)
        {
            await _categoryRepository.Update(category);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryRepository.RemoveById(id);
            return Ok();
        }
    }
}
