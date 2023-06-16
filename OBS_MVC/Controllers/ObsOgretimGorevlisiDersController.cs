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
    public class ObsOgretimGorevlisiDersController : Controller
    {
        private readonly OBSContext _context;

        public ObsOgretimGorevlisiDersController(OBSContext context)
        {
            _context = context;
        }

        // GET: ObsOgretimGorevlisiDers
        public async Task<IActionResult> Index()
        {
            var oBSContext = _context.OgretimGorevlisiDersleri.Include(o => o.DonemDers).Include(o => o.OgretimGorevlisi);
            return View(await oBSContext.ToListAsync());
        }

        // GET: ObsOgretimGorevlisiDers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgretimGorevlisiDers = await _context.OgretimGorevlisiDersleri
                .Include(o => o.DonemDers)
                .Include(o => o.OgretimGorevlisi)
                .FirstOrDefaultAsync(m => m.OgretmenDersId == id);
            if (obsOgretimGorevlisiDers == null)
            {
                return NotFound();
            }

            return View(obsOgretimGorevlisiDers);
        }

        // GET: ObsOgretimGorevlisiDers/Create
        public IActionResult Create()
        {
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler, "DonemDersId", "DonemDersId");
            ViewData["OgretimGorevlisiId"] = new SelectList(_context.OgretimGorevlileri, "OgretimGorevlisiId", "Ad");
            return View();
        }

        // POST: ObsOgretimGorevlisiDers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OgretmenDersId,OgretimGorevlisiId,DonemDersId")] ObsOgretimGorevlisiDers obsOgretimGorevlisiDers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obsOgretimGorevlisiDers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler, "DonemDersId", "DonemDersId", obsOgretimGorevlisiDers.DonemDersId);
            ViewData["OgretimGorevlisiId"] = new SelectList(_context.OgretimGorevlileri, "OgretimGorevlisiId", "Ad", obsOgretimGorevlisiDers.OgretimGorevlisiId);
            return View(obsOgretimGorevlisiDers);
        }

        // GET: ObsOgretimGorevlisiDers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgretimGorevlisiDers = await _context.OgretimGorevlisiDersleri.FindAsync(id);
            if (obsOgretimGorevlisiDers == null)
            {
                return NotFound();
            }
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler, "DonemDersId", "DonemDersId", obsOgretimGorevlisiDers.DonemDersId);
            ViewData["OgretimGorevlisiId"] = new SelectList(_context.OgretimGorevlileri, "OgretimGorevlisiId", "Ad", obsOgretimGorevlisiDers.OgretimGorevlisiId);
            return View(obsOgretimGorevlisiDers);
        }

        // POST: ObsOgretimGorevlisiDers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OgretmenDersId,OgretimGorevlisiId,DonemDersId")] ObsOgretimGorevlisiDers obsOgretimGorevlisiDers)
        {
            if (id != obsOgretimGorevlisiDers.OgretmenDersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obsOgretimGorevlisiDers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsOgretimGorevlisiDersExists(obsOgretimGorevlisiDers.OgretmenDersId))
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
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler, "DonemDersId", "DonemDersId", obsOgretimGorevlisiDers.DonemDersId);
            ViewData["OgretimGorevlisiId"] = new SelectList(_context.OgretimGorevlileri, "OgretimGorevlisiId", "Ad", obsOgretimGorevlisiDers.OgretimGorevlisiId);
            return View(obsOgretimGorevlisiDers);
        }

        // GET: ObsOgretimGorevlisiDers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgretimGorevlisiDers = await _context.OgretimGorevlisiDersleri
                .Include(o => o.DonemDers)
                .Include(o => o.OgretimGorevlisi)
                .FirstOrDefaultAsync(m => m.OgretmenDersId == id);
            if (obsOgretimGorevlisiDers == null)
            {
                return NotFound();
            }

            return View(obsOgretimGorevlisiDers);
        }

        // POST: ObsOgretimGorevlisiDers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsOgretimGorevlisiDers = await _context.OgretimGorevlisiDersleri.FindAsync(id);
            _context.OgretimGorevlisiDersleri.Remove(obsOgretimGorevlisiDers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObsOgretimGorevlisiDersExists(int id)
        {
            return _context.OgretimGorevlisiDersleri.Any(e => e.OgretmenDersId == id);
        }
    }
}
