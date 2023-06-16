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
    public class ObsOgrenciSinavController : Controller
    {
        private readonly OBSContext _context;

        public ObsOgrenciSinavController(OBSContext context)
        {
            _context = context;
        }

        // GET: ObsOgrenciSinav
        public async Task<IActionResult> Index()
        {
            var oBSContext = _context.OgrenciSinavlar.Include(o => o.Ogrenci).Include(o => o.Sinav);
            return View(await oBSContext.ToListAsync());
        }

        // GET: ObsOgrenciSinav/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgrenciSinav = await _context.OgrenciSinavlar
                .Include(o => o.Ogrenci)
                .Include(o => o.Sinav)
                .FirstOrDefaultAsync(m => m.OgrenciSinavId == id);
            if (obsOgrenciSinav == null)
            {
                return NotFound();
            }

            return View(obsOgrenciSinav);
        }

        // GET: ObsOgrenciSinav/Create
        public IActionResult Create()
        {
            ViewData["OgrenciId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "Ad");
            ViewData["SinavId"] = new SelectList(_context.SinavTarihleri, "SinavId", "SinavId");
            return View();
        }

        // POST: ObsOgrenciSinav/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OgrenciSinavId,OgrenciId,SinavId,Notu")] ObsOgrenciSinav obsOgrenciSinav)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obsOgrenciSinav);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OgrenciId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "Ad", obsOgrenciSinav.OgrenciId);
            ViewData["SinavId"] = new SelectList(_context.SinavTarihleri, "SinavId", "SinavId", obsOgrenciSinav.SinavId);
            return View(obsOgrenciSinav);
        }

        // GET: ObsOgrenciSinav/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgrenciSinav = await _context.OgrenciSinavlar.FindAsync(id);
            if (obsOgrenciSinav == null)
            {
                return NotFound();
            }
            ViewData["OgrenciId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "Ad", obsOgrenciSinav.OgrenciId);
            ViewData["SinavId"] = new SelectList(_context.SinavTarihleri, "SinavId", "SinavId", obsOgrenciSinav.SinavId);
            return View(obsOgrenciSinav);
        }

        // POST: ObsOgrenciSinav/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OgrenciSinavId,OgrenciId,SinavId,Notu")] ObsOgrenciSinav obsOgrenciSinav)
        {
            if (id != obsOgrenciSinav.OgrenciSinavId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obsOgrenciSinav);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsOgrenciSinavExists(obsOgrenciSinav.OgrenciSinavId))
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
            ViewData["OgrenciId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "Ad", obsOgrenciSinav.OgrenciId);
            ViewData["SinavId"] = new SelectList(_context.SinavTarihleri, "SinavId", "SinavId", obsOgrenciSinav.SinavId);
            return View(obsOgrenciSinav);
        }

        // GET: ObsOgrenciSinav/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgrenciSinav = await _context.OgrenciSinavlar
                .Include(o => o.Ogrenci)
                .Include(o => o.Sinav)
                .FirstOrDefaultAsync(m => m.OgrenciSinavId == id);
            if (obsOgrenciSinav == null)
            {
                return NotFound();
            }

            return View(obsOgrenciSinav);
        }

        // POST: ObsOgrenciSinav/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsOgrenciSinav = await _context.OgrenciSinavlar.FindAsync(id);
            _context.OgrenciSinavlar.Remove(obsOgrenciSinav);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObsOgrenciSinavExists(int id)
        {
            return _context.OgrenciSinavlar.Any(e => e.OgrenciSinavId == id);
        }
    }
}
