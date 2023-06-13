using Microsoft.AspNetCore.Mvc;
using GW.Api.Data.Models;
using GW.Api.Data.Repository;

namespace GW.Api.Controllers.UserController
{
    // [ApiController]
    // [Route("api/[controller]")]
    // public class UserController : ControllerBase
    // {
    //     private readonly UserRepository _userRepository;

    //     public UserController(Context context)
    //     {
    //         _userRepository = new UserRepository(context);
    //     }

    //     [HttpGet]
    //     public async Task<IActionResult> Get()
    //     {
    //         var Users = await _userRepository.GetAll();
    //         return Ok(Users);
    //     }

    //     [HttpGet("{id}")]
    //     public async Task<IActionResult> Get(int id)
    //     {
    //         var user = await _userRepository.GetById(id);
    //         return Ok(user);
    //     }

    //     [HttpPost]
    //     public async Task<IActionResult> Post([FromBody] UserModel user)
    //     {
    //         await _userRepository.Add(user);
    //         return Ok();
    //     }

    //     [HttpPut]
    //     public async Task<IActionResult> Put([FromBody] UserModel user)
    //     {
    //         await _userRepository.Update(user);
    //         return Ok();
    //     }

    //     [HttpDelete("{id}")]
    //     public async Task<IActionResult> Delete(int id)
    //     {
    //         await _userRepository.RemoveById(id);
    //         return Ok();
    //     }
    // }
}
