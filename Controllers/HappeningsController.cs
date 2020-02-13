using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Terminarz.Data;
using Terminarz.Models;

namespace Terminarz.Controllers
{
    public class HappeningsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HappeningsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Happenings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Happenings.ToListAsync());
        }

        // GET: Happenings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var happening = await _context.Happenings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (happening == null)
            {
                return NotFound();
            }

            return View(happening);
        }

        // GET: Happenings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Happenings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("City,Address,Suit,ID,Name,Priority,Date,Time,Description")] Happening happening)
        {
            if (ModelState.IsValid)
            {
                _context.Add(happening);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(happening);
        }

        // GET: Happenings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var happening = await _context.Happenings.FindAsync(id);
            if (happening == null)
            {
                return NotFound();
            }
            return View(happening);
        }

        // POST: Happenings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("City,Address,Suit,ID,Name,Priority,Date,Time,Description")] Happening happening)
        {
            if (id != happening.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(happening);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HappeningExists(happening.ID))
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
            return View(happening);
        }

        // GET: Happenings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var happening = await _context.Happenings
                .FirstOrDefaultAsync(m => m.ID == id);
            if (happening == null)
            {
                return NotFound();
            }

            return View(happening);
        }

        // POST: Happenings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var happening = await _context.Happenings.FindAsync(id);
            _context.Happenings.Remove(happening);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HappeningExists(int id)
        {
            return _context.Happenings.Any(e => e.ID == id);
        }
    }
}
