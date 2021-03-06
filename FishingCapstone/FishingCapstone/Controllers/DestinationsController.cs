﻿using System;
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
            return View(await _context.Destination.OrderBy(d=>d.DestinationName).ToListAsync());
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
            destination.AvailableSpecies = GetDestinationSpecies(destination.DestinationId);
            return View(destination);
        }

        // GET: Destinations/SelectCompare/5
        public async Task<IActionResult> SelectCompare (int? id)
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
            ViewData["MonthId"] = new SelectList(_context.Month, "MonthId", "MonthName");
            ViewData["DestinationToCompare"] = new SelectList(_context.Destination.Where(d=>d.DestinationId != destination.DestinationId), "DestinationId", "DestinationName");

            return View(destination);
        }

        // GET: Destinations/Compare/5
        public async Task<IActionResult> Compare(int? DestinationId, int? DestinationToCompare, int? MonthId)
        {
            if (DestinationId == null) //Check/set first destination
            {
                return NotFound();
            }
            var destination1 = await _context.Destination
                .FirstOrDefaultAsync(d => d.DestinationId == DestinationId);
            if (destination1 == null)
            {
                return NotFound();
            }

            if (DestinationToCompare == null) //Check/set second destination
            {
                return NotFound();
            }
            var destination2 = await _context.Destination
                .FirstOrDefaultAsync(d => d.DestinationId == DestinationToCompare);
            if (destination2 == null)
            {
                return NotFound();
            }
            if (MonthId == null) //Check/set month
            {
                return NotFound();
            }
            var month = await _context.Month
                .FirstOrDefaultAsync(m => m.MonthId == MonthId);
            if (month == null)
            {
                return NotFound();
            }

            DestinationComparision destinationComparision = new DestinationComparision();
            destination1.DestinationComparision = destinationComparision;
            destination1.DestinationComparision.Destination2 = destination2;
            destination1.DestinationComparision.MonthToCompare = month;
            var speciesList = GetDestinationSpecies(destination1.DestinationId, destination2.DestinationId);
            destination1.DestinationComparision.SpeciesList = speciesList;
            GetDestinationComparison(destination1.DestinationId);


            return View(destination1);
        }

        // GET: Destinations/Calendar/5
        public async Task<IActionResult> Calendar(int? id)
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
            GetDestCalendar(destination.DestinationId, speciesList);

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

            if (destination != null)
            {
                availableSpecies = _context.DestSpeciesMonth.Where(d => d.DSMDestinationId == id).Select(d => d.Species).Distinct().OrderBy(d => d.SpeciesId).ToList();
                return availableSpecies;
            }
            else 
            {
                return availableSpecies;
            }
        }
        public List<Species> GetDestinationSpecies(int destination1id, int destination2id)
        {
            var destination = _context.Destination.Where(d => d.DestinationId == destination1id);
            var availableSpecies = new List<Species>();

            if (destination != null)
            {
                availableSpecies = _context.DestSpeciesMonth.Where(d => d.DSMDestinationId == destination1id || d.DSMDestinationId == destination2id).Select(d => d.Species).Distinct().OrderBy(d => d.SpeciesId).ToList();
                return availableSpecies;
            }
            else
            {
                return availableSpecies;
            }
        }
        public CalendarByDestination GetDestCalendar(int destinationId, List<Species> speciesList)
        {
            CalendarByDestination destCalendar = new CalendarByDestination();
            destCalendar.CalendarByDestinationRows = new List<CalendarByDestinationRow>();
            var thisDestination = _context.Destination.Where(d => d.DestinationId == destinationId).FirstOrDefault();
            for (int i = 0; i < speciesList.Count; i++) //Create a row for every species at Destination
            {
                CalendarByDestinationRow calendarRow = new CalendarByDestinationRow();
                string[] ratingsArray = new string[12]; //Array of ratings for every month
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
                destCalendar.CalendarByDestinationRows.Add(calendarRow);
            }
            thisDestination.Calendar = destCalendar;
            return destCalendar;
        }
        public CompareChart GetDestinationComparison(int destinationId)
        {
            var thisDestination = _context.Destination.Where(d => d.DestinationId == destinationId).FirstOrDefault();
            var otherDestination = thisDestination.DestinationComparision.Destination2;
            int thisMonthId = thisDestination.DestinationComparision.MonthToCompare.MonthId;
            CompareChart compareChart = new CompareChart();
            compareChart.CompareChartRows = new List<CompareChartRow>();
            var speciesList = thisDestination.DestinationComparision.SpeciesList;
            for (int i = 0; i < speciesList.Count; i++)
            {
                CompareChartRow compareChartRow = new CompareChartRow();
                string[] ratingsArray = new string[2];
                var currentSpeciesId = speciesList[i].SpeciesId;
                var currentSpecies = _context.Species.Where(s => s.SpeciesId == currentSpeciesId).FirstOrDefault();
                compareChartRow.Species = currentSpecies;
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        var ratingToAdd = _context.DestSpeciesMonth.Where(d => d.DSMDestinationId == thisDestination.DestinationId && d.DSMSpeciesId == currentSpeciesId && d.DSMMonthId == thisMonthId).Select(d => d.Rating.RatingName).FirstOrDefault();
                        if (ratingToAdd!=null)
                        {
                            ratingsArray[j] = ratingToAdd;
                        }
                        else
                        {
                            ratingsArray[j] = "NA";
                        }

                    }
                    else
                    {
                        var ratingToAdd = _context.DestSpeciesMonth.Where(d => d.DSMDestinationId == otherDestination.DestinationId && d.DSMSpeciesId == currentSpeciesId && d.DSMMonthId == thisMonthId).Select(d => d.Rating.RatingName).FirstOrDefault();
                        if (ratingToAdd != null)
                        {
                            ratingsArray[j] = ratingToAdd;
                        }
                        else
                        {
                            ratingsArray[j] = "NA";
                        }
                    }
                }
                compareChartRow.SpeciesRatings = ratingsArray;
                compareChart.CompareChartRows.Add(compareChartRow);
            }
            thisDestination.DestinationComparision.CompareChart = compareChart;
            return compareChart;
        }
    }
}
