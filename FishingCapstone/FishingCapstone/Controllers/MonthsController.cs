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
    public class MonthsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonthsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Months
        public async Task<IActionResult> Index()
        {
            return View(await _context.Month.ToListAsync());
        }

        // GET: Months/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var month = await _context.Month
                .FirstOrDefaultAsync(m => m.MonthId == id);
            if (month == null)
            {
                return NotFound();
            }

            return View(month);
        }

        // GET: Months/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Months/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MonthId,MonthName")] Month month)
        {
            if (ModelState.IsValid)
            {
                _context.Add(month);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(month);
        }

        // GET: Months/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var month = await _context.Month.FindAsync(id);
            if (month == null)
            {
                return NotFound();
            }
            return View(month);
        }

        // POST: Months/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MonthId,MonthName")] Month month)
        {
            if (id != month.MonthId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(month);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonthExists(month.MonthId))
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
            return View(month);
        }

        // GET: Months/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var month = await _context.Month
                .FirstOrDefaultAsync(m => m.MonthId == id);
            if (month == null)
            {
                return NotFound();
            }

            return View(month);
        }

        // POST: Months/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var month = await _context.Month.FindAsync(id);
            _context.Month.Remove(month);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Months/CalendarByMonth/5
        public async Task<IActionResult> CalendarByMonth(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var month = await _context.Month
                .FirstOrDefaultAsync(m => m.MonthId == id);
            if (month == null)
            {
                return NotFound();
            }
            //GetBestDestinationsByMonth();
            int ratingValue = 4;
            var bestSpeciesList = GetBestSpeciesForMonth(month.MonthId, ratingValue);
            var bestDestinationsList = GetBestDestinationsForMonth(month.MonthId, ratingValue);
            GetCalendarByMonth(month.MonthId, ratingValue, bestSpeciesList, bestDestinationsList);

            return View(month);
        }
        public List<Species> GetBestSpeciesForMonth(int monthId, int ratingValue)
        {
            var bestSpecies = new List<Species>();
            bestSpecies = _context.DestSpeciesMonth.Where(d => d.DSMMonthId == monthId && d.Rating.RatingNumber == ratingValue).Select(d => d.Species).Distinct().OrderBy(d => d.SpeciesName).ToList();
            return bestSpecies;
        }
        public List<Destination> GetBestDestinationsForMonth(int monthId, int ratingValue)
        {
            var bestDestinations = new List<Destination>();
            bestDestinations = _context.DestSpeciesMonth.Where(d => d.DSMMonthId == monthId && d.Rating.RatingNumber == ratingValue).Select(d => d.Destination).Distinct().OrderBy(d => d.DestinationId).ToList();
            return bestDestinations;
        }
        public CalendarByMonth GetCalendarByMonth(int monthId, int ratingValue, List<Species> bestSpeciesList, List<Destination> bestDestinationsList)
        {
            CalendarByMonth calendarByMonth = new CalendarByMonth();
            string[] ratingsArray = new string[bestSpeciesList.Count];
            calendarByMonth.CalendarByMonthRows = new List<CalendarByMonthRow>();
            var thisMonth = _context.Month.Where(m => m.MonthId == monthId).Select(m => m).FirstOrDefault();
            thisMonth.BestSpecies = bestSpeciesList;
            var thisRating = _context.Rating.Where(r => r.RatingNumber == ratingValue).Select(r => r).FirstOrDefault();
            for (int i = 0; i < bestDestinationsList.Count; i++) //<===The Row is going to be grouped by Month, and each column of row with show the rating of species with Best fishing for this month
            {
                CalendarByMonthRow calendarByMonthRow = new CalendarByMonthRow();
                calendarByMonthRow.Month = thisMonth;
                calendarByMonthRow.BestSpeciesForMonth = bestSpeciesList;
                calendarByMonthRow.Rating = thisRating;
                calendarByMonthRow.Destination = bestDestinationsList[i];
                for (int j = 0; j < bestSpeciesList.Count; j++)
                {
                    var ratingToAdd = _context.DestSpeciesMonth.Where(d => d.DSMDestinationId == bestDestinationsList[i].DestinationId && d.DSMSpeciesId == bestSpeciesList[j].SpeciesId && d.DSMMonthId == monthId).Select(d => d.Rating.RatingName).FirstOrDefault();
                    if (ratingToAdd!=null)
                    {
                        ratingsArray[j] = ratingToAdd;
                    }
                    else
                    {
                        ratingsArray[j] = "NA";
                    }
                }
                calendarByMonthRow.SpeciesRatings = ratingsArray;
                calendarByMonth.CalendarByMonthRows.Add(calendarByMonthRow);


            }
            thisMonth.CalendarByMonth = calendarByMonth;
            return calendarByMonth;
        }
        private bool MonthExists(int id)
        {
            return _context.Month.Any(e => e.MonthId == id);
        }
    }
}
