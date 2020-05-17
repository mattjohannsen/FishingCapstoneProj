using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FishingCapstone.Data;
using FishingCapstone.Models;

namespace FishingCapstone.Controllers
{
    public class SpeciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpeciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Species
        public async Task<IActionResult> Index()
        {
            return View(await _context.Species
                .OrderBy(s=>s.SpeciesName)
                .ToListAsync());
        }

        // GET: Species/Details/5
        public async Task<IActionResult> Calendar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await _context.Species
                .FirstOrDefaultAsync(m => m.SpeciesId == id);
            if (species == null)
            {
                return NotFound();
            }
            var destinationList = GetSpeciesDestinations(species);
            species.BestDestinations = destinationList;
            GetCalendarBySpecies(species.SpeciesId, destinationList);
            return View(species);
        }

        // GET: Species/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await _context.Species
                .FirstOrDefaultAsync(m => m.SpeciesId == id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        // GET: Species/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Species/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpeciesId,SpeciesName")] Species species)
        {
            if (ModelState.IsValid)
            {
                _context.Add(species);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(species);
        }

        // GET: Species/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await _context.Species.FindAsync(id);
            if (species == null)
            {
                return NotFound();
            }
            return View(species);
        }

        // POST: Species/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpeciesId,SpeciesName")] Species species)
        {
            if (id != species.SpeciesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(species);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpeciesExists(species.SpeciesId))
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
            return View(species);
        }

        // GET: Species/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var species = await _context.Species
                .FirstOrDefaultAsync(m => m.SpeciesId == id);
            if (species == null)
            {
                return NotFound();
            }

            return View(species);
        }

        // POST: Species/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var species = await _context.Species.FindAsync(id);
            _context.Species.Remove(species);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpeciesExists(int id)
        {
            return _context.Species.Any(e => e.SpeciesId == id);
        }

        public List<Destination> GetSpeciesDestinations(Species species)
        {
            var destinationsList = new List<Destination>();
            if (species != null)
            {
                destinationsList = _context.DestSpeciesMonth.Where(d => d.DSMSpeciesId == species.SpeciesId).Select(d => d.Destination).Distinct().OrderBy(d => d.DestinationName).ToList();
                return destinationsList;
            }
            else
            {
                return destinationsList;
            }
        }

        public CalendarBySpecies GetCalendarBySpecies(int speciesId, List<Destination> destinationsList)
        {
            CalendarBySpecies speciesCalendar = new CalendarBySpecies();
            speciesCalendar.CalendarBySpeciesRows = new List<CalendarBySpeciesRow>();
            var thisSpecies = _context.Species.Where(s => s.SpeciesId == speciesId).FirstOrDefault();
            for (int i = 0; i < destinationsList.Count; i++)
            {
                CalendarBySpeciesRow calendarRow = new CalendarBySpeciesRow();
                string[] ratingsArray = new string[12];
                calendarRow.Species = thisSpecies;
                var currentDestinationId = destinationsList[i].DestinationId;
                var currentDestination = _context.Destination.Where(d => d.DestinationId == currentDestinationId).FirstOrDefault();
                calendarRow.Destination = currentDestination;

                for (int j = 0; j < 12; j++)
                {
                    var ratingToAdd = _context.DestSpeciesMonth.Where(d => d.DSMDestinationId == currentDestinationId && d.DSMSpeciesId == speciesId && d.DSMMonthId == j + 1).Select(d => d.Rating.RatingName).FirstOrDefault();
                    ratingsArray[j] = ratingToAdd;
                }
                calendarRow.MonthlyRatings = ratingsArray;
                speciesCalendar.CalendarBySpeciesRows.Add(calendarRow);
            }
            thisSpecies.Calendar = speciesCalendar;
            return speciesCalendar;
        }
    }
}
