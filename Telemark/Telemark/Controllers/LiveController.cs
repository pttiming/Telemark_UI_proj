using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Controllers
{
    public class LiveController : Controller
    {
        // GET: LiveController
        public ActionResult Index()
        {
            return View();
        }

        // GET: LiveController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LiveController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LiveController/Create
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

        // GET: LiveController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LiveController/Edit/5
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

        // GET: LiveController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LiveController/Delete/5
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

        public IActionResult Announcer()
        {

            return View();
        }

        public IActionResult SelfieOutput()
        {

            return View();
        }

        public IActionResult SelfieController()
        {

            return View();
        }
    }
}
