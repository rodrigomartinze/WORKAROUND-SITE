using Microsoft.AspNetCore.Mvc;
using WorkAroundSite.Models;

namespace WorkAroundSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly VacantesService _vacantesService;

        public HomeController(VacantesService vacantesService)
        {
            _vacantesService = vacantesService;
        }

        public IActionResult Index()
        {
            var vacantes = _vacantesService.GetVacantes();
            return View(vacantes);
        }
    }
}