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
using Telemark.ViewModels;

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
            races = races.OrderBy(r => r.next_date).ToList();
            DirectorEvents_ViewModel directorRaces = new DirectorEvents_ViewModel();
            directorRaces.rsuRaces = races;
            directorRaces.importedRaces = _context.Races.Where(r => r.director_id == director.Id).ToList();
            return View(directorRaces);
        }

        // GET: Directors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var race = _context.Races.Where(r => r.race_id == id).FirstOrDefault();

            RaceDetails_ViewModel raceDetails = new RaceDetails_ViewModel();
            raceDetails.race = race;
            raceDetails.participants = _context.Participants.Where(p => p.race_id == race.id).ToList();
            raceDetails.events = _context.Events.Where(p => p.race_id == race.id).ToList();
            raceDetails.locations = _context.Locations.Where(p => p.race_id == race.id).ToList();
            raceDetails.users = _context.TextUsers.Where(p => p.race_id == race.id).ToList();
            raceDetails.infoMessages = _context.Info.Where(p => p.race_id == race.id).ToList();


            if (race == null)
            {
                return NotFound();
            }

            return View(raceDetails);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Director director)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            director.IdentityUserId = userId;
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

        public async Task<IActionResult> ImportRace(int id)
        {
            var director = GetDirector();
            var raceObject = await _rsu.GetRace(director.RSU_API_Key, director.RSU_API_Secret, id);
            var race = raceObject.race;
            RaceToDB(race, director);
            await EventToDB(race, director);
            return RedirectToAction(nameof(Index));
        }

        public void RaceToDB(Race race, Director director)
        {
            race.director_id = director.Id;
            _context.Add(race);
            _context.SaveChanges();
        }

        public async Task EventToDB(Race race, Director director)
        {
            foreach (Event e in race.events)
            {
                e.race_id = _context.Races.Where(r => r.race_id == race.race_id).Select(r => r.id).FirstOrDefault();
                _context.Add(e);
                _context.SaveChanges();
                double count = await _rsu.GetParticipantCount(director.RSU_API_Key, director.RSU_API_Secret, race.race_id, e.event_id);
                //int page = (int)Math.Ceiling(count / 50);
                var participants = await _rsu.GetParticipants(director.RSU_API_Key, director.RSU_API_Secret, race.race_id, e.event_id);
                if(participants.Count != 0)
                {
                    ParticipantToDB(participants, race.race_id, e.event_id);
                }
            }
        }
        public void ParticipantToDB(List<ParticipantObject> participants, int raceId, int eventId)
        {
            foreach (ParticipantObject p in participants)
            {
                Participant np = new Participant();
                np.race_id = _context.Races.Where(r => r.race_id == raceId).Select(r => r.id).FirstOrDefault();
                np.event_id = _context.Events.Where(e => e.event_id == eventId).Select(r => r.id).FirstOrDefault();
                np.first_name = p.user.first_name;
                np.last_name = p.user.last_name;
                np.email = p.user.email;
                np.dob = p.user.dob;
                np.gender = p.user.gender;
                np.phone = ConvertPhoneNumber(p.user.phone);
                np.registration_id = (int)p.registration_id;
                np.bib_num = p.bib_num;
                np.chip_num = p.chip_num;
                np.age = p.age;
                np.registration_date = p.registration_date;
                np.team_id = p.team_id;
                np.team_name = p.team_name;
                np.team_type_id = p.team_type_id;
                np.team_type = p.team_type;
                np.team_gender = p.team_gender;
                np.team_bib_num = p.team_bib_num;
                np.last_modified = p.last_modified;
                _context.Add(np);
            }
        }

        public string ConvertPhoneNumber(string number)
        {
            string newNumber = "";
            if(number != null)
            {
                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i].ToString() != "-")
                    {
                        newNumber += number[i];
                    }
                }
            }

            return newNumber;
        }
    }
}
