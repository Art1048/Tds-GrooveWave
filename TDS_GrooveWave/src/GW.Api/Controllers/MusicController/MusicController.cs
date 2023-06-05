using Microsoft.AspNetCore.Mvc;
using GW.Api.Data.Models;
using GW.Api.Data.Repository;

namespace GW.Api.Controllers.MusicController
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly MusicRepository _MusicRepository;

        public MusicController(Context context)
        {
            _MusicRepository = new MusicRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Musics = await _MusicRepository.GetAll();
            return Ok(Musics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Music = await _MusicRepository.GetById(id);
            return Ok(Music);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MusicModel Music)
        {
            var response = await _MusicRepository.Add(Music);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] MusicModel Music)
        {
            await _MusicRepository.Update(Music);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _MusicRepository.RemoveById(id);
            return Ok();
        }
    }
}
