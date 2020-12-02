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
using Telemark.Services;
using Telemark.ViewModels;

namespace Telemark.Controllers
{
    public class LocationsController : Controller
    {
        public GoogleService _google;

        public ApplicationDbContext _context;

        public LocationsController(GoogleService google, ApplicationDbContext context)
        {
            _context = context;
            _google = google;
        }
        // GET: LocationsController
        public ActionResult Index()
        {
            DirectorLocations_ViewModel dl = new DirectorLocations_ViewModel();
            dl.director = GetDirector();
            dl.locations = _context.Locations.Where(m => m.director_id == dl.director.Id).ToList();
            dl.races = _context.Races.Where(r => r.director_id == dl.director.Id).ToList();
            IEnumerable<SelectListItem> selectRaces = from r in dl.races
                                                      select new SelectListItem
                                                      {
                                                          Text = r.name,
                                                          Value = r.id.ToString()
                                                      };
            dl.racelist = selectRaces;

            return View(dl);
        }

        // GET: LocationsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LocationsController/Create
        public ActionResult Create(DirectorLocations_ViewModel dl)
        {
            dl.director = GetDirector();
            dl.locations = _context.Locations.Where(m => m.director_id == dl.director.Id).ToList();
            dl.races = _context.Races.Where(r => r.director_id == dl.director.Id).ToList();
            IEnumerable<SelectListItem> selectRaces = from r in dl.races
                                                      select new SelectListItem
                                                      {
                                                          Text = r.name,
                                                          Value = r.id.ToString()
                                                      };
            dl.racelist = selectRaces;
            return View(dl);
        }

        // POST: LocationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Location location)
        {
            try
            {
                var director = GetDirector();
                location.director = director;
                location.director_id = director.Id;
                location = await _google.GetGeoCode(location);
                location.Race = _context.Races.Where(r => r.id == location.race_id).FirstOrDefault();
                _context.Locations.Add(location);
                _context.SaveChanges();
                return RedirectToAction("Index", "Locations");
            }
            catch
            {
                return View();
            }
        }

        // GET: LocationsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LocationsController/Edit/5
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

        // GET: LocationsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LocationsController/Delete/5
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
