using Microsoft.AspNetCore.Mvc;

namespace CafePilot.Server.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
