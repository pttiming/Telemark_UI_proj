using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telemark.Data;
using Telemark.Models;
using Telemark.Services;

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
            return View();
        }

        // GET: LocationsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LocationsController/Create
        public ActionResult Create(int id)
        {
            ViewBag.race_id = id;
            return View();
        }

        // POST: LocationsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Location location)
        {
            try
            {
                var newLocation = await _google.GetGeoCode(location);
                newLocation.race_id = 76;
                newLocation.Id = 0;
                _context.Locations.Add(newLocation);
                _context.SaveChanges();
                return RedirectToAction("Index", "Directors");
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
    }
}
