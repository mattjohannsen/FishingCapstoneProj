using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FishingCapstone.Data;
using FishingCapstone.Models;
using Microsoft.AspNetCore.Hosting;
using FishingCapstone.ViewModels;
using System.IO;

namespace FishingCapstone.Controllers
{
    public class PhotosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public PhotosController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Photos
        //public async Task<IActionResult> Index()
        //{
        //    var applicationDbContext = _context.Photos.Include(p => p.Trip);

        //    return View(await applicationDbContext.ToListAsync());
        //}
        public async Task<IActionResult> Index()
        {
            var photo = await _context.Photos.ToListAsync();
            return View(photo);
        }

        public IActionResult New()
        {
            ViewData["PhotoTripId"] = new SelectList(_context.Trip, "TripId", "TripName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(PhotosViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);

                Photos photo = new Photos
                {
                    PhotoFile = uniqueFileName,
                    PhotoTripId = model.PhotoTripId,
                    PhotoCaption = model.PhotoCaption,
                };
                _context.Add(photo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private string UploadedFile(PhotosViewModel model)
        {
            string uniqueFileName = null;

            if (model.PhotoFile != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.PhotoFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        // GET: Photos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photos = await _context.Photos
                .Include(p => p.Trip)
                .FirstOrDefaultAsync(m => m.PhotosId == id);
            if (photos == null)
            {
                return NotFound();
            }

            return View(photos);
        }

        // GET: Photos/Create
        public IActionResult Create()
        {
            ViewData["PhotoTripId"] = new SelectList(_context.Trip, "TripId", "TripName");
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhotosId,PhotoFile,PhotoTripId,PhotoCaption,PhotoLat,PhotoLong,PhotoDate,PhotoData")] Photos photos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(photos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhotoTripId"] = new SelectList(_context.Trip, "TripId", "TripName", photos.PhotoTripId);
            return View(photos);
        }

        // GET: Photos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photos = await _context.Photos.FindAsync(id);
            if (photos == null)
            {
                return NotFound();
            }
            ViewData["PhotoTripId"] = new SelectList(_context.Trip, "TripId", "TripName", photos.PhotoTripId);
            return View(photos);
        }

        // POST: Photos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PhotosId,PhotoFile,PhotoTripId,PhotoCaption,PhotoLat,PhotoLong,PhotoDate,PhotoData")] Photos photos)
        {
            if (id != photos.PhotosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(photos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhotosExists(photos.PhotosId))
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
            ViewData["PhotoTripId"] = new SelectList(_context.Trip, "TripId", "TripName", photos.PhotoTripId);
            return View(photos);
        }

        // GET: Photos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photos = await _context.Photos
                .Include(p => p.Trip)
                .FirstOrDefaultAsync(m => m.PhotosId == id);
            if (photos == null)
            {
                return NotFound();
            }

            return View(photos);
        }

        // POST: Photos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var photos = await _context.Photos.FindAsync(id);
            _context.Photos.Remove(photos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhotosExists(int id)
        {
            return _context.Photos.Any(e => e.PhotosId == id);
        }
    }
}
