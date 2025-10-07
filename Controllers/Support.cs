using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkAroundSite.Controllers
{
    public class Support : Controller
    {
        // GET: Support
        public ActionResult Index()
        {
            return View();
        }

        // GET: Support/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Support/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Support/Create
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

        // GET: Support/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Support/Edit/5
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

        // GET: Support/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Support/Delete/5
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
