using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkAroundSite.Controllers
{
    public class SupportController : Controller
    {
        // GET: SupportController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SupportController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupportController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupportController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupportController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupportController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupportController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
