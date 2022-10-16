using Microsoft.AspNetCore.Mvc;

namespace TribalWarsCloneApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VillageController:ControllerBase
    {

        public VillageController()
        {

        }

        [HttpPost]
        public void Post([FromBody]string newVillageName)
        {

        }
    }
}
