using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OBS_MVC.Models;

namespace OBS_MVC.Controllers
{
    public class ObsDonemController : Controller
    {
        private readonly OBSContext _context;

        public ObsDonemController(OBSContext context)
        {
            _context = context;
        }

        // GET: ObsDonem
        public async Task<IActionResult> Index()
        {
            return View(await _context.Donemler.ToListAsync());
        }

        // GET: ObsDonem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDonem = await _context.Donemler
                .FirstOrDefaultAsync(m => m.DonemId == id);
            if (obsDonem == null)
            {
                return NotFound();
            }

            return View(obsDonem);
        }

        // GET: ObsDonem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObsDonem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonemId,Yil,DonemTip")] ObsDonem obsDonem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obsDonem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obsDonem);
        }

        // GET: ObsDonem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDonem = await _context.Donemler.FindAsync(id);
            if (obsDonem == null)
            {
                return NotFound();
            }
            return View(obsDonem);
        }

        // POST: ObsDonem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonemId,Yil,DonemTip")] ObsDonem obsDonem)
        {
            if (id != obsDonem.DonemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obsDonem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsDonemExists(obsDonem.DonemId))
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
            return View(obsDonem);
        }

        // GET: ObsDonem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDonem = await _context.Donemler
                .FirstOrDefaultAsync(m => m.DonemId == id);
            if (obsDonem == null)
            {
                return NotFound();
            }

            return View(obsDonem);
        }

        // POST: ObsDonem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsDonem = await _context.Donemler.FindAsync(id);
            _context.Donemler.Remove(obsDonem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObsDonemExists(int id)
        {
            return _context.Donemler.Any(e => e.DonemId == id);
        }
    }
}
