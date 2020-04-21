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
using FishingCapstone.Contracts;
using System.Security.Claims;

namespace FishingCapstone.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TripsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trip.Include(t => t.Destination).Include(t => t.Explorer).Include(t => t.Month);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .Include(t => t.Destination)
                .Include(t => t.Explorer)
                .Include(t => t.Month)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }
            var tripPhotos = _context.Photos.Where(p => p.PhotoTripId == trip.TripId).ToList();
            trip.TripPhotos = tripPhotos;
            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create(int? DestinationId, int? MonthId)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var explorer = _context.Explorer.Where(e => e.IdentityUser.Id == userId).FirstOrDefault();
            var destination = _context.Destination.Where(d => d.DestinationId == DestinationId).FirstOrDefault();
            var month = _context.Month.Where(m => m.MonthId == MonthId).FirstOrDefault();
            ViewData["ExplorerId"] = explorer.ExplorerId;
            ViewData["DestinationId"] = destination.DestinationId;
            ViewData["TripMonthId"] = month.MonthId;
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripId,ExplorerId,DestinationId,TripName,TripGuideService,TripMonthId,TripStart,TripEnd")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                //var explorer = _context.Explorer.Where(e => e.IdentityUser.Id == userId).FirstOrDefault();
                //trip.ExplorerId = explorer.ExplorerId;
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["DestinationId"] = new SelectList(_context.Destination, "DestinationId", "DestinationId", trip.DestinationId);
            //ViewData["ExplorerId"] = new SelectList(_context.Explorer, "ExplorerId", "ExplorerId", trip.ExplorerId);
            //ViewData["TripMonthId"] = new SelectList(_context.Month, "MonthId", "MonthId", trip.TripMonthId);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var explorer = _context.Explorer.Where(e => e.IdentityUser.Id == userId).FirstOrDefault();
            ViewData["ExplorerId"] = explorer.ExplorerId;
            ViewData["DestinationId"] = new SelectList(_context.Destination, "DestinationId", "DestinationName", trip.DestinationId);
            //ViewData["ExplorerId"] = new SelectList(_context.Explorer, "ExplorerId", "ExplorerId", trip.ExplorerId);
            ViewData["TripMonthId"] = new SelectList(_context.Month, "MonthId", "MonthName", trip.TripMonthId);
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripId,ExplorerId,DestinationId,TripName,TripGuideService,TripMonthId,TripStart,TripEnd")] Trip trip)
        {
            if (id != trip.TripId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripId))
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
            ViewData["DestinationId"] = new SelectList(_context.Destination, "DestinationId", "DestinationId", trip.DestinationId);
            ViewData["ExplorerId"] = new SelectList(_context.Explorer, "ExplorerId", "ExplorerId", trip.ExplorerId);
            ViewData["TripMonthId"] = new SelectList(_context.Month, "MonthId", "MonthId", trip.TripMonthId);
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .Include(t => t.Destination)
                .Include(t => t.Explorer)
                .Include(t => t.Month)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trip.FindAsync(id);
            _context.Trip.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _context.Trip.Any(e => e.TripId == id);
        }
    }
}
