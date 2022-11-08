using Microsoft.AspNetCore.Mvc;
using TribalWarsCloneDomain.Models;

namespace TribalWarsCloneServer.Controller
{
    [ApiController]
    [Route("villages/[action]")]
    public class VillageController : ControllerBase
    {
        public VillageController()
        {
            
        }
        public string Get(string name)
        {
            Village v = Game.Instance.world.Villages[name];
            return v.Name;
        }

        public void Post()
        {

        }

        public void Put()
        {

        }

        public void Delete(string name)
        {

        }


    }
}
