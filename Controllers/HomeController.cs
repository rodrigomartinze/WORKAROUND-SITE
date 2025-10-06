using Microsoft.AspNetCore.Mvc;

namespace WorkAroundSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
