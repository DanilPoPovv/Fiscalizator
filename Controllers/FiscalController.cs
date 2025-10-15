using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiscalizator.Controllers
{
    public class FiscalController : Controller
    {
        // GET: FiscalController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FiscalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FiscalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FiscalController/Create
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

        // GET: FiscalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FiscalController/Edit/5
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

        // GET: FiscalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FiscalController/Delete/5
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
