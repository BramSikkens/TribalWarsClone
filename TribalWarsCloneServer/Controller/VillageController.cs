using Microsoft.AspNetCore.Mvc;
using TribalWarsCloneDomain.Models;

namespace TribalWarsCloneServer.Controller
{
    [ApiController]
    [Route("/villages")]
    public class VillageController : ControllerBase
    {
        public VillageController()
        {
            
        }
        [HttpGet]
        public  IResult Get(string name)
        {
            try
            {
                Village v = Game.Instance.world.Villages[name];
                return Results.Ok(v);
            }
            catch
            {
                return Results.NotFound();
            }
         
        }


        [HttpPost]
        public  IResult CreateVillage()
        {
            try
            {
                Game.Instance.world.createNewVillage("stom", "stom");
                return Results.Ok(Game.Instance.world.Villages["stom"]);
            }
            catch (Exception e)
            {
                return Results.NotFound();
            }
        }

    


    }
}
