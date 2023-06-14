using Microsoft.AspNetCore.Mvc;
using GW.Api.Data.Models;
using GW.Api.Data.Repository;
using GW.Api.Controllers.MusicServ;

namespace GW.Api.Controllers.PlayListController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayListController : ControllerBase
    {


    [HttpGet]
        public IActionResult Get(
         [FromServices] Context context) => Ok(context.PlayListModel!.ToList());

        [HttpGet("{id:int}")]
        public IActionResult Get([FromServices] Context context , [FromRoute] int id){
            PlayListModel PlayList = context.PlayListModel.FirstOrDefault(x => x.PlayListId == id);
            if(PlayList != null){
                return Ok(PlayList);
            }
            else{
                return NotFound();
            }
        }

        [HttpGet("/api/PlayList/UserId={UserId:int}")]
        public IActionResult GetResult([FromServices] Context context , [FromRoute] int UserId){
            PlayListModel PlayList = context.PlayListModel.FirstOrDefault(x => x.UserID == UserId);
            if(PlayList != null){
                return Ok(PlayList);
            }
            else{
                return NotFound();
            }
        }
        
        [HttpPost]
        public IActionResult Post([FromServices] Context context, [FromBody] PlayListModel PlayList){
            UserModel? User = context.UserModel?.FirstOrDefault(x => x.UserId == PlayList.UserID);

            if(User != null){

                context.PlayListModel!.Add(PlayList);
                if(User.PlayLists == null){
                    User.PlayLists = new List<PlayListModel>();
                }
                User.PlayLists.Add(PlayList);
                context.UserModel.Update(User);
                context.SaveChanges();
                return Ok(PlayList);
            }
            else{
                return BadRequest();
            } 
        }

        [HttpPut("{id:int}")]
        public IActionResult Put([FromServices] Context context ,[FromRoute] int id, [FromBody] PlayListModel PlayList){
            PlayListModel PlayListDB = context.PlayListModel.FirstOrDefault(x => x.PlayListId == id);
            if(PlayListDB != null){
                PlayListDB.Name = PlayList.Name;

                context.PlayListModel!.Update(PlayListDB);
                context.SaveChanges();
                return Ok(PlayList);
            }
            else{
                return NotFound();
            }
        }

        [HttpPut("/api/PlayListAddMusic={id:int}/MusicId={MusicId:int}")]
        public virtual async Task<IActionResult> Put([FromServices] Context context , [FromRoute] int id , [FromRoute] int MusicId){
            PlayListModel PlayListDB = context.PlayListModel.FirstOrDefault(x => x.PlayListId == id);

            if(PlayListDB != null){
                MusicService musicController = new MusicService();
                MusicModel Music  = await musicController.GetMusicFromData(context, MusicId);
                if(Music != null){

                    PlayListDB.Musics?.Add(Music);
                    context.PlayListModel!.Update(PlayListDB);
                    context.SaveChanges();
                    return Ok(PlayListDB);

                }else{
                    return NotFound("Deu ruim aqui");
                }
                
            }
            else{
                return NotFound("Deu ruim aqui em baixo");
            }
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromServices] Context context , [FromRoute] int id){
            PlayListModel PlayList = context.PlayListModel.FirstOrDefault(x => x.PlayListId == id);
            if(PlayList != null){
                context.PlayListModel!.Remove(PlayList);
                context.SaveChanges();
                return Ok(PlayList);
            }
            else{
                return NotFound();
            }
        }
    }
}
