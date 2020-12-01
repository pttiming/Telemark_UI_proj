using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Telemark.Controllers
{
    public class InfoMessagesController : Controller
    {
        // GET: InfoMessagesController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InfoMessagesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InfoMessagesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InfoMessagesController/Create
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

        // GET: InfoMessagesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InfoMessagesController/Edit/5
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

        // GET: InfoMessagesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InfoMessagesController/Delete/5
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
