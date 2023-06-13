using Microsoft.AspNetCore.Mvc;
using GW.Api.Data.Models;
using GW.Api.Data.Repository;

namespace GW.Api.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get(
         [FromServices] Context context) => Ok(context.UserModel!.ToList());

        [HttpGet("{id:int}")]
        public IActionResult Get([FromServices] Context context , [FromRoute] int id){
            UserModel User = context.UserModel.FirstOrDefault(x => x.UserId == id);
            if(User != null){
                return Ok(User);
            }
            else{
                return NotFound();
            }
        }
        
        [HttpPost]
        public IActionResult Post([FromServices] Context context, [FromBody] UserModel User){
            context.UserModel!.Add(User);
            context.SaveChanges();
            return Ok(User);
        }

        [HttpPut]
        public IActionResult Put([FromServices] Context context , [FromBody] UserModel User){
            UserModel UserDB = context.UserModel.FirstOrDefault(x => x.UserId == User.UserId);
            if(UserDB != null){
                context.UserModel!.Update(User);
                context.SaveChanges();
                return Ok(User);
            }
            else{
                return NotFound();
            }
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromServices] Context context , [FromRoute] int id){
            UserModel User = context.UserModel.FirstOrDefault(x => x.UserId == id);
            if(User != null){
                context.UserModel!.Remove(User);
                context.SaveChanges();
                return Ok(User);
            }
            else{
                return NotFound();
            }
        }
    }
}
