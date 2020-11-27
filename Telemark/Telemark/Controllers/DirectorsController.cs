using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Telemark.Data;
using Telemark.Models;
using Telemark.Services;

namespace Telemark.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RSU_Service _rsu;

        public DirectorsController(ApplicationDbContext context, RSU_Service rsu)
        {
            _context = context;
            _rsu = rsu;
        }

        // GET: Directors
        public async Task<IActionResult> Index()
        {
            var director =  GetDirector();
            if (director == null)
            {
                return RedirectToAction("Create", "Directors");
            }
            var raceresults = await _rsu.GetRaces(director.RSU_API_Key, director.RSU_API_Secret);
            List<Race> races = new List<Race>();
            foreach (RaceObject ro in raceresults.races)
            {
                races.Add(ro.race);
            }
            //var applicationDbContext = _context.Directors.Include(d => d.IdentityUser);
            return View(races);
        }

        // GET: Directors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.Directors
                .Include(d => d.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Director director)
        {
      
                director.Longitude = 0;
                director.Latitude = 0;
                _context.Add(director);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
        }

        // GET: Directors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", director.IdentityUserId);
            return View(director);
        }

        // POST: Directors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,CompanyName,IdentityUserId,Address1,Address2,City,State,ZipCode,Country,Latitude,Longitude,RSU_API_Key,RSU_API_Secret")] Director director)
        {
            if (id != director.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(director);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorExists(director.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", director.IdentityUserId);
            return View(director);
        }

        // GET: Directors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var director = await _context.Directors
                .Include(d => d.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var director = await _context.Directors.FindAsync(id);
            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorExists(int id)
        {
            return _context.Directors.Any(e => e.Id == id);
        }

        public Director GetDirector()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var director = _context.Directors.Where(d => d.IdentityUserId == userId).SingleOrDefault();

            return director;
        }
    }
}
