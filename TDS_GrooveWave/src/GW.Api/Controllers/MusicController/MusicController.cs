using Microsoft.AspNetCore.Mvc;
using GW.Api.Data.Models;
using GW.Api.Data.Repository;
using GW.Api.Controllers.MusicServ;


namespace GW.Api.Controllers.MusicController
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get(
         [FromServices] Context context) => Ok(context.MusicModel!.ToList());


        
        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> Get([FromServices] Context context , [FromRoute] int id)
        {
            MusicModel Music = context.MusicModel.FirstOrDefault(x => x.MusicId == id);
            if(Music != null){
                return Ok(Music);
            }
            else{
                MusicService MusicService = new MusicService();
                MusicModel MusicDeazer = await MusicService.GetMusic(id);

                if(MusicDeazer != null)
                {
                    MusicDeazer.MusicId = id;
                    Post(MusicDeazer ,context);
                    return Ok(MusicDeazer);
                }
                else{
                    return NotFound();
                }  
            }
            
        }

        [HttpPost]
        public MusicModel Post([FromBody] MusicModel Music , [FromServices] Context context){
            context.MusicModel!.Add(Music);
            context.SaveChanges();
            return Music;
        }
    }
}
