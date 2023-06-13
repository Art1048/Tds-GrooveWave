using Microsoft.AspNetCore.Mvc;
using GW.Api.Data.Models;
using GW.Api.Data.Repository;

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
        
        [HttpPost]
        public IActionResult Post([FromServices] Context context, [FromBody] PlayListModel PlayList){
            context.PlayListModel!.Add(PlayList);
            context.SaveChanges();
            return Ok(PlayList);
        }

        [HttpPut]
        public IActionResult Put([FromServices] Context context , [FromBody] PlayListModel PlayList){
            PlayListModel PlayListDB = context.PlayListModel.FirstOrDefault(x => x.PlayListId == PlayList.PlayListId);
            if(PlayListDB != null){
                context.PlayListModel!.Update(PlayList);
                context.SaveChanges();
                return Ok(PlayList);
            }
            else{
                return NotFound();
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
