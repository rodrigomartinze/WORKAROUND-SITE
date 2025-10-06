using Microsoft.AspNetCore.Mvc;

namespace WorkAroundSite.Controllers
{
    public class MyJobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
