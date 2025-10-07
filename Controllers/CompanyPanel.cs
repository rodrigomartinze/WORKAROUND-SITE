using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WorkAroundSite.Controllers
{
    public class CompanyPanel : Controller
    {
        // GET: CompanyPanel
        public ActionResult Index()
        {
            return View();
        }

        // GET: CompanyPanel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyPanel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyPanel/Create
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

        // GET: CompanyPanel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompanyPanel/Edit/5
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

        // GET: CompanyPanel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyPanel/Delete/5
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
