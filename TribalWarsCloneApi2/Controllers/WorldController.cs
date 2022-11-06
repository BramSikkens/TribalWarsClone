using Microsoft.AspNetCore.Mvc;

namespace TribalWarsCloneApi2.Controllers
{
    public class WorldController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
