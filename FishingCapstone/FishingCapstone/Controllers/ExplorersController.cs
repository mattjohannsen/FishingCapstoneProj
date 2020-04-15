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
    public class ExplorersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExplorersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Explorers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Explorer.Include(e => e.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Explorers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var explorer = await _context.Explorer
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.ExplorerId == id);
            if (explorer == null)
            {
                return NotFound();
            }

            return View(explorer);
        }

        // GET: Explorers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Explorers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExplorerId,IdentityUserId,ExplorerFirst,ExplorerLast")] Explorer explorer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(explorer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", explorer.IdentityUserId);
            return View(explorer);
        }

        // GET: Explorers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var explorer = await _context.Explorer.FindAsync(id);
            if (explorer == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", explorer.IdentityUserId);
            return View(explorer);
        }

        // POST: Explorers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExplorerId,IdentityUserId,ExplorerFirst,ExplorerLast")] Explorer explorer)
        {
            if (id != explorer.ExplorerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(explorer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExplorerExists(explorer.ExplorerId))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", explorer.IdentityUserId);
            return View(explorer);
        }

        // GET: Explorers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var explorer = await _context.Explorer
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.ExplorerId == id);
            if (explorer == null)
            {
                return NotFound();
            }

            return View(explorer);
        }

        // POST: Explorers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var explorer = await _context.Explorer.FindAsync(id);
            _context.Explorer.Remove(explorer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExplorerExists(int id)
        {
            return _context.Explorer.Any(e => e.ExplorerId == id);
        }
    }
}
