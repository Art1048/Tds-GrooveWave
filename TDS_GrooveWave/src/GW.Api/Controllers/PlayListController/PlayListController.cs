using Microsoft.AspNetCore.Mvc;
using GW.Api.Data.Models;
using GW.Api.Data.Repository;

namespace GW.Api.Controllers.PlayListController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayListController : ControllerBase
    {
        private readonly PlayListRepository _PlayListRepository;

        public PlayListController(Context context)
        {
            _PlayListRepository = new PlayListRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var PlayLists = await _PlayListRepository.GetAll();
            return Ok(PlayLists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var PlayList = await _PlayListRepository.GetById(id);
            return Ok(PlayList);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlayListModel PlayList)
        {
            await _PlayListRepository.Add(PlayList);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PlayListModel PlayList)
        {
            await _PlayListRepository.Update(PlayList);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Console.WriteLine(id);
            await _PlayListRepository.RemoveById(id);
            return Ok();
        }
    }
}
