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
    public class ObsDonemDersController : Controller
    {
        private readonly OBSContext _context;

        public ObsDonemDersController(OBSContext context)
        {
            _context = context;
        }

        // GET: ObsDonemDers
        public async Task<IActionResult> Index()
        {
            var oBSContext = _context.DonemDersler.Include(o => o.Ders).Include(o => o.Donem).Include(o => o.OgretimGorevlisi);
            return View(await oBSContext.ToListAsync());
        }

        // GET: ObsDonemDers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDonemDers = await _context.DonemDersler
                .Include(o => o.Ders)
                .Include(o => o.Donem)
                .Include(o => o.OgretimGorevlisi)
                .FirstOrDefaultAsync(m => m.DonemDersId == id);
            if (obsDonemDers == null)
            {
                return NotFound();
            }

            return View(obsDonemDers);
        }

        // GET: ObsDonemDers/Create
        public IActionResult Create()
        {
            ViewData["DersId"] = new SelectList(_context.Dersler, "DersId", "Ad");
            ViewData["DonemId"] = new SelectList(_context.Donemler, "DonemId", "DonemId");
            ViewData["OgretimGorevlisiId"] = new SelectList(_context.OgretimGorevlileri, "OgretimGorevlisiId", "Ad");
            return View();
        }

        // POST: ObsDonemDers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonemDersId,DonemId,DersId,OgretimGorevlisiId")] ObsDonemDers obsDonemDers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obsDonemDers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DersId"] = new SelectList(_context.Dersler, "DersId", "Ad", obsDonemDers.DersId);
            ViewData["DonemId"] = new SelectList(_context.Donemler, "DonemId", "DonemId", obsDonemDers.DonemId);
            ViewData["OgretimGorevlisiId"] = new SelectList(_context.OgretimGorevlileri, "OgretimGorevlisiId", "Ad", obsDonemDers.OgretimGorevlisiId);
            return View(obsDonemDers);
        }

        // GET: ObsDonemDers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDonemDers = await _context.DonemDersler.FindAsync(id);
            if (obsDonemDers == null)
            {
                return NotFound();
            }
            ViewData["DersId"] = new SelectList(_context.Dersler, "DersId", "Ad", obsDonemDers.DersId);
            ViewData["DonemId"] = new SelectList(_context.Donemler, "DonemId", "DonemId", obsDonemDers.DonemId);
            ViewData["OgretimGorevlisiId"] = new SelectList(_context.OgretimGorevlileri, "OgretimGorevlisiId", "Ad", obsDonemDers.OgretimGorevlisiId);
            return View(obsDonemDers);
        }

        // POST: ObsDonemDers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DonemDersId,DonemId,DersId,OgretimGorevlisiId")] ObsDonemDers obsDonemDers)
        {
            if (id != obsDonemDers.DonemDersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obsDonemDers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsDonemDersExists(obsDonemDers.DonemDersId))
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
            ViewData["DersId"] = new SelectList(_context.Dersler, "DersId", "Ad", obsDonemDers.DersId);
            ViewData["DonemId"] = new SelectList(_context.Donemler, "DonemId", "DonemId", obsDonemDers.DonemId);
            ViewData["OgretimGorevlisiId"] = new SelectList(_context.OgretimGorevlileri, "OgretimGorevlisiId", "Ad", obsDonemDers.OgretimGorevlisiId);
            return View(obsDonemDers);
        }

        // GET: ObsDonemDers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDonemDers = await _context.DonemDersler
                .Include(o => o.Ders)
                .Include(o => o.Donem)
                .Include(o => o.OgretimGorevlisi)
                .FirstOrDefaultAsync(m => m.DonemDersId == id);
            if (obsDonemDers == null)
            {
                return NotFound();
            }

            return View(obsDonemDers);
        }

        // POST: ObsDonemDers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsDonemDers = _context.DonemDersler.Include(x=>x.OgrenciDonemDers).FirstOrDefault(o=>o.DonemDersId == id);
            if(obsDonemDers?.OgrenciDonemDers?.Count>0)
                return RedirectToAction(nameof(Index));
            _context.DonemDersler.Remove(obsDonemDers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObsDonemDersExists(int id)
        {
            return _context.DonemDersler.Any(e => e.DonemDersId == id);
        }
    }
}
