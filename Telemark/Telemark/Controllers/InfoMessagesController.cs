using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Telemark.Data;
using Telemark.Models;
using Telemark.ViewModels;

namespace Telemark.Controllers
{
    public class InfoMessagesController : Controller
    {
        public ApplicationDbContext _context;
        public InfoMessagesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: InfoMessagesController
        public ActionResult Index()
        {
            DirectorInfoMessage_ViewModel dim = new DirectorInfoMessage_ViewModel();
            dim.director = GetDirector();
            dim.messages = _context.Info.Where(m => m.director_id == dim.director.Id).ToList();
            dim.races = _context.Races.Where(r => r.director_id == dim.director.Id).ToList();
            IEnumerable<SelectListItem> selectRaces = from r in dim.races
                                                      select new SelectListItem
                                                      {
                                                          Text = r.name,
                                                          Value = r.id.ToString()
                                                      };
            dim.racelist = selectRaces;
            
            return View(dim);
        }

        // GET: InfoMessagesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InfoMessagesController/Create
        public ActionResult Create(DirectorInfoMessage_ViewModel model)
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
        public Director GetDirector()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var director = _context.Directors.Where(d => d.IdentityUserId == userId).SingleOrDefault();

            return director;
        }
    }
}
