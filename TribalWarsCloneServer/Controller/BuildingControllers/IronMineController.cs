using Microsoft.AspNetCore.Mvc;
using TribalWarsCloneDomain.Models;
using TribalWarsCloneDomain.Models.Buildings;

namespace TribalWarsCloneServer.Controller.BuildingControllers
{
    [ApiController]
    [Route("villages/ironmine")]
    public class IronMineController : ControllerBase
    {
        public IronMineController()
        {

        }

        [HttpGet]
        public IResult Get(string id)
        {
            IronMine? i = Game.Instance.world.Villages[id].IronMine as IronMine;
            return Results.Ok(i);
        }

        
    }
}
