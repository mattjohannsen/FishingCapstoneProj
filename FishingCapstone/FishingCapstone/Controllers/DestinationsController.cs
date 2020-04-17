using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FishingCapstone.Data;
using FishingCapstone.Models;
using FishingCapstone.ViewModels;

namespace FishingCapstone.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DestinationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Destinations
        public async Task<IActionResult> Index()
        {
            return View(await _context.Destination.ToListAsync());
        }

        // GET: Destinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destination
                .FirstOrDefaultAsync(m => m.DestinationId == id);
            if (destination == null)
            {
                return NotFound();
            }
            var speciesList = GetDestinationSpecies(destination.DestinationId);
            destination.AvailableSpecies = speciesList;
            var dsmList = GetDSMByDestination(destination.DestinationId);
            destination.DSMCalender = dsmList;

            return View(destination);
        }

        // GET: Destinations/Details/5
        public async Task<IActionResult> DestinationCalendar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destination
                .FirstOrDefaultAsync(m => m.DestinationId == id);
            if (destination == null)
            {
                return NotFound();
            }
            //int parsedId = Int32.Parse(destination.DestinationId);

            var speciesList = GetDestinationSpecies(destination.DestinationId);
            destination.AvailableSpecies = speciesList;
            var dsmList = GetDSMByDestination(destination.DestinationId);
            destination.DSMCalender = dsmList;
            //CalendarViewModel calendarViewModel = new CalendarViewModel();
            //calendarViewModel.Destination = destination;
            var ratingsList = GetDestCalendar(destination.DestinationId, speciesList);

            return View(destination);
        }

        // GET: Destinations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DestinationId,DestinationName,DestinationLat,DestinationLong")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        // GET: Destinations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destination.FindAsync(id);
            if (destination == null)
            {
                return NotFound();
            }
            return View(destination);
        }

        // POST: Destinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DestinationId,DestinationName,DestinationLat,DestinationLong")] Destination destination)
        {
            if (id != destination.DestinationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destination);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinationExists(destination.DestinationId))
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
            return View(destination);
        }

        // GET: Destinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destination
                .FirstOrDefaultAsync(m => m.DestinationId == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // POST: Destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destination = await _context.Destination.FindAsync(id);
            _context.Destination.Remove(destination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationExists(int id)
        {
            return _context.Destination.Any(e => e.DestinationId == id);
        }

        public List<Species> GetDestinationSpecies(int id)
        {
            var destination = _context.Destination.Where(d => d.DestinationId == id);
            var availableSpecies = new List<Species>();

            //var totalSpecies = new List<int>();
            if (destination != null)
            {
                availableSpecies = _context.DestSpeciesMonth.Where(d => d.DSMDestinationId == id).Select(d => d.Species).Distinct().OrderBy(d => d.SpeciesId).ToList(); //<==Working list that gives Species
                //var monthlyrating = _context.DestSpeciesMonth.Where(d => d.DSMDestinationId == id && d.DSMSpeciesId == tempSpeciesid && d.DSMMonthId == tempMonthid).Select(d => d.Rating.RatingName).FirstOrDefault();
                //availableSpecies = availableSpecies.Select(s => s.SpeciesId).Distinct();
                //totalSpecies = _context.DestSpeciesMonth.
                //destination.AvailableSpecies = availableSpecies;
                return availableSpecies;
            }
            else 
            {
                //
                return availableSpecies;
            }
        }

        public List<DestSpeciesMonth> GetDSMByDestination(int id)
        {
            var destination = _context.Destination.Where(d => d.DestinationId == id);
            var dsmrAvailableSpecies = new List<DestSpeciesMonth>();
            if (destination != null)
            {
                dsmrAvailableSpecies = _context.DestSpeciesMonth.Where(d => d.DSMDestinationId == id).OrderBy(d=>d.Species.SpeciesName).ThenBy(d=>d.DSMMonthId).Select(d => d).ToList(); //<==Working list that gives Species
                    for (int i = 0; i < dsmrAvailableSpecies.Count; i++)
                    {
                        if (dsmrAvailableSpecies[i].Month==null)
                        {
                        var dsmrMonth = _context.Month.Where(m => m.MonthId == dsmrAvailableSpecies[i].DSMMonthId).FirstOrDefault();
                        dsmrAvailableSpecies[i].Month = dsmrMonth;
                        }
                        if (dsmrAvailableSpecies[i].Rating == null)
                        {
                        var dsmrRating = _context.Rating.Where(m => m.RatingId == dsmrAvailableSpecies[i].DSMRatingId).FirstOrDefault();
                        dsmrAvailableSpecies[i].Rating = dsmrRating;
                        }
                    }
                return dsmrAvailableSpecies;
            }
            else
            {
                return dsmrAvailableSpecies;
            }
        }
        public Calendar GetDestCalendar(int destinationId, List<Species> speciesList)
        {
            Calendar destCalendar = new Calendar();
            destCalendar.CalendarRows = new List<CalendarRow>();
            var thisDestination = _context.Destination.Where(d => d.DestinationId == destinationId).FirstOrDefault();
            for (int i = 0; i < speciesList.Count; i++)
            {
                CalendarRow calendarRow = new CalendarRow();
                string[] ratingsArray = new string[12];
                calendarRow.Destination = thisDestination;
                var currentSpeciesId = speciesList[i].SpeciesId;
                var currentSpecies = _context.Species.Where(s => s.SpeciesId == currentSpeciesId).FirstOrDefault();
                calendarRow.Species = currentSpecies;
                
                for (int j = 0; j < 12; j++)
                {
                    var ratingToAdd = _context.DestSpeciesMonth.Where(d => d.DSMDestinationId == destinationId && d.DSMSpeciesId == currentSpeciesId && d.DSMMonthId == j + 1).Select(d => d.Rating.RatingName).FirstOrDefault();
                    ratingsArray[j] = ratingToAdd;
                }
                calendarRow.MonthlyRatings = ratingsArray;
                destCalendar.CalendarRows.Add(calendarRow);
            }
            thisDestination.Calendar = destCalendar;
            return destCalendar;
        }
    }
}
