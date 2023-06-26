using Microsoft.AspNetCore.Mvc;
using GW.Api.Data.Models;
using GW.Api.Data.Repository;
using GW.Api.Controllers.MusicServ;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GW.Api.Controllers.PlayListController
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayListController : ControllerBase
    {


        [HttpGet]
        public IActionResult Get(
         [FromServices] Context context) => Ok(context.PlayListModel!.Include(u => u.Musics).ToList());


        [HttpGet("{id:int}")]
        public IActionResult Get([FromServices] Context context , [FromRoute] int id){
            PlayListModel? PlayList = context.PlayListModel.Include(u => u.Musics).FirstOrDefault(x => x.PlayListId == id);
            if(PlayList != null){
                return Ok(PlayList);
            }
            else{
                return NotFound();
            }
        }

        [HttpGet("/api/PlayList/UserId={UserId:int}")]
        public IActionResult GetResult([FromServices] Context context , [FromRoute] int UserId){
            List<PlayListModel> PlayList = context.PlayListModel!.Include(u => u.Musics).Where(u => u.UserID == UserId).ToList();
            if(PlayList != null){
                return Ok(PlayList);
            }
            else{
                return NotFound();
            }
        }

        [HttpGet("/api/PlayListFavorita/UserId={UserId:int}")]
        public IActionResult GetFavorite([FromServices] Context context , [FromRoute] int UserId){
            PlayListModel PlayList = context.PlayListModel!.Include(u => u.Musics).Where(u => u.UserID == UserId && u.IsFavorite == true).FirstOrDefault();
            if(PlayList != null){
                return Ok(PlayList);
            }
            else{
                return NotFound();
            }
        }
        
        [HttpPost("/api/CreatePlayList/UserId={UserId:int}")]
        public IActionResult Post([FromServices] Context context, [FromQuery] string PlaylistName , [FromRoute] int UserId){
            UserModel? User = context.UserModel.Include(u => u.PlayLists).ThenInclude(u => u.Musics).Include(u => u.PlayListFavorita).ThenInclude(u => u.Musics).FirstOrDefault(x => x.UserId == UserId);
            int PlaylistLastID = context.PlayListModel.OrderBy(playlist => playlist.PlayListId).Last().PlayListId;

            if(User != null){
                PlayListModel PlayList = new PlayListModel();
                PlayList.Name = PlaylistName;
                PlayList.PlayListId = PlaylistLastID + 1;
                PlayList.UserID = UserId;
                PlayList.IsFavorite = false;
                PlayList.Musics = new List<MusicModel>();

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
                return Ok(PlayListDB);
            }
            else{
                return NotFound();
            }
        }

        [HttpPut("/api/PlayListOperationMusic={id:int}/MusicId={MusicId:int}/Activity={i:bool}")]
        public virtual async Task<IActionResult> Put([FromServices] Context context , [FromRoute] int id , [FromRoute] int MusicId , [FromRoute] bool i){
            if(i == true){
                PlayListModel PlayListDB = context.PlayListModel.Include(u => u.Musics).FirstOrDefault(x => x.PlayListId == id);

                if(PlayListDB != null){
                    MusicService musicController = new MusicService();
                    MusicModel Music  = await musicController.GetMusicFromData(context, MusicId);
                    if(Music != null){
                        MusicModel MusicDB = context.MusicModel.FirstOrDefault(u => u.MusicId == Music.MusicId);
                        if(MusicDB == null){
                            context.MusicModel.Add(Music);
                        }
                        context.SaveChanges();
                        PlayListDB.Musics.Add(Music);
                        context.PlayListModel!.Update(PlayListDB);
                        context.SaveChanges();
                        return Ok(PlayListDB);

                    }else{
                        return NotFound("Música não existe");
                    }
                    
                }
                else{
                    return NotFound("Playlist não existe");
                }
            }
            else{
                PlayListModel PlayListDB = context.PlayListModel.Include(u => u.Musics).FirstOrDefault(x => x.PlayListId == id);

                if(PlayListDB != null){
                    MusicModel MusicPlaylist = PlayListDB.Musics.Find(u => u.MusicId == MusicId);
                    if(MusicPlaylist != null){

                        PlayListDB.Musics.Remove(MusicPlaylist);
                        context.PlayListModel!.Update(PlayListDB);
                        context.SaveChanges();
                        return Ok(PlayListDB);

                    }else{
                        return NotFound("Música não existe");
                    }
                    
                }
                else{
                    return NotFound("Playlist não existe");
                }
            }
            
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromServices] Context context , [FromRoute] int id){
            PlayListModel PlayList = context.PlayListModel.Include(u => u.Musics).FirstOrDefault(x => x.PlayListId == id);
            if(PlayList != null){
                PlayList.Musics.RemoveAll(u => true);
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
