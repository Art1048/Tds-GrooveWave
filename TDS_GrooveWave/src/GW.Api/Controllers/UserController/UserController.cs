using Microsoft.AspNetCore.Mvc;
using GW.Api.Data.Models;
using GW.Api.Data.Repository;
using Microsoft.EntityFrameworkCore;
using GW.Api.OAuth;

namespace GW.Api.Controllers.UserController
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        //private AuthService _authService;

        [HttpGet]
        public IActionResult Get(
         [FromServices] Context context) => Ok(context.UserModel?.Include(u => u.PlayLists).ThenInclude(u => u.Musics).Include(u => u.PlayListFavorita).ThenInclude(u => u.Musics).ToList());

        [HttpGet("{id:int}")]
        public IActionResult Get([FromServices] Context context , [FromRoute] int id){
            UserModel User = context.UserModel.Include(u => u.PlayLists).ThenInclude(u => u.Musics).Include(u => u.PlayListFavorita).ThenInclude(u => u.Musics).FirstOrDefault(x => x.UserId == id);
            if(User != null){
                return Ok(User);
            }
            else{
                return NotFound();
            }
        }
        
        [HttpPost]
        public IActionResult Post([FromServices] Context context, [FromBody] UserModel User){

            //bool IsValid = _authService.RegisterUser(User , context);
            // if(IsValid == false){
            //     return BadRequest();
            // }
            int UserLastID = 0;
            int PlaylistLastID = 0;

            UserModel UserDB = context.UserModel.FirstOrDefault(x => x.UserId == 1);

            if(UserDB != null){
                UserLastID = context.UserModel.OrderBy(user => user.UserId).Last().UserId;
                PlaylistLastID = context.PlayListModel.OrderBy(playlist => playlist.PlayListId).Last().PlayListId;
            }
            
            User.UserId = UserLastID + 1;
            List<PlayListModel>? PlayLists = new List<PlayListModel>();
            PlayListModel? PlayListFavorita = new PlayListModel("Favoritas" , true);
            PlayListFavorita.PlayListId = PlaylistLastID + 1;
            PlayListFavorita.UserID = User.UserId;
            PlayListFavorita.IsFavorite = true;

            User.PlayListFavorita = PlayListFavorita;
            User.PlayLists = PlayLists; 

            context.UserModel!.Add(User);
            context.SaveChanges();
            return Ok(User);
        }


        [HttpPut]
        public IActionResult Put([FromServices] Context context , [FromBody] UserModel User){
            UserModel UserDB = context.UserModel.FirstOrDefault(x => x.UserId == User.UserId);
            if(UserDB != null){
                UserDB.FirstName = User.FirstName;
                UserDB.LastName = User.LastName;
                UserDB.Phone = User.Phone;
                UserDB.Email = User.Email;
                UserDB.Password = User.Password;
                context.UserModel!.Update(UserDB);
                context.SaveChanges();
                return Ok(UserDB);
            }
            else{
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromServices] Context context , [FromRoute] int id){
            UserModel User = context.UserModel.Include(u => u.PlayLists).Include(u => u.PlayListFavorita).FirstOrDefault(x => x.UserId == id);;
            if(User != null){
                List<PlayListModel>? PlayLists = User.PlayLists;
                PlayListModel? PlayListFavorita = User.PlayListFavorita;
                if(PlayListFavorita != null){
                    context.PlayListModel!.Remove(PlayListFavorita);
                }
                if(PlayLists != null){
                    foreach(PlayListModel e in PlayLists){
                        context.PlayListModel!.Remove(e);
                    }
                }
                
                context.UserModel!.Remove(User);
                context.SaveChanges();
                return Ok(User);
            }
            else{
                return NotFound();
            }
        }

        // [HttpPost]
        // public IActionResult Login([FromServices] Context context ,string email, string password)
        // {
        //     var user = context.UserModel?.FirstOrDefault(u => u.Email == email && u.Password == password);
        //     if (user != null)
        //     {

        //         return Ok($"UserId{user.UserId.ToString()}");
        //     }
        //     return BadRequest();
        // }

        // public IActionResult Logout()
        // {
        //     return Ok("Log out!");
        // }
    }
}
