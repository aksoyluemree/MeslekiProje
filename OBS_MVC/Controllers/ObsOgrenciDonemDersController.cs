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
    public class ObsOgrenciDonemDersController : Controller
    {
        private readonly OBSContext _context;

        public ObsOgrenciDonemDersController(OBSContext context)
        {
            _context = context;
        }

        // GET: ObsOgrenciDonemDers
        public async Task<IActionResult> Index()
        {
            var oBSContext = _context.OgrenciDonemDersler.Include(o => o.DonemDers).Include(o => o.Ogrenci);
            return View(await oBSContext.ToListAsync());
        }

        // GET: ObsOgrenciDonemDers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgrenciDonemDers = await _context.OgrenciDonemDersler
                .Include(o => o.DonemDers)
                .Include(o => o.Ogrenci)
                .FirstOrDefaultAsync(m => m.KayıtId == id);
            if (obsOgrenciDonemDers == null)
            {
                return NotFound();
            }

            return View(obsOgrenciDonemDers);
        }

        // GET: ObsOgrenciDonemDers/Create
        public IActionResult Create()
        {
            //ViewData["DonemDersId"] = new SelectList(_context.DonemDersler, "DonemDersId", "DonemDersId");
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler.Include(x => x.Ders), "DonemDersId", "DonemDersId");
            ViewData["OgrenciId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "Ad");
            return View();
        }

        // POST: ObsOgrenciDonemDers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KayıtId,DonemDersId,OgrenciId,Vize1,Vize2,FinalNot,Ortalama,BasariDurumTip")] ObsOgrenciDonemDers obsOgrenciDonemDers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obsOgrenciDonemDers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["DonemDersId"] = new SelectList(_context.DonemDersler, "DonemDersId", "DonemDersId", obsOgrenciDonemDers.DonemDersId);
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler.Include(x => x.Ders), "DonemDersId", "DonemDersId", obsOgrenciDonemDers.DonemDersId);
            ViewData["OgrenciId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "Ad", obsOgrenciDonemDers.OgrenciId);
            return View(obsOgrenciDonemDers);
        }

        // GET: ObsOgrenciDonemDers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgrenciDonemDers = await _context.OgrenciDonemDersler.FindAsync(id);
            if (obsOgrenciDonemDers == null)
            {
                return NotFound();
            }
            //ViewData["DonemDersId"] = new SelectList(_context.DonemDersler, "DonemDersId", "DonemDersId", obsOgrenciDonemDers.DonemDersId);
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler.Include(x => x.Ders), "DonemDersId", "DonemDersId", obsOgrenciDonemDers.DonemDersId);
            ViewData["OgrenciId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "Ad", obsOgrenciDonemDers.OgrenciId);
            return View(obsOgrenciDonemDers);
        }

        // POST: ObsOgrenciDonemDers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KayıtId,DonemDersId,OgrenciId,Vize1,Vize2,FinalNot,Ortalama,BasariDurumTip")] ObsOgrenciDonemDers obsOgrenciDonemDers)
        {
            if (id != obsOgrenciDonemDers.KayıtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obsOgrenciDonemDers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsOgrenciDonemDersExists(obsOgrenciDonemDers.KayıtId))
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
            //ViewData["DonemDersId"] = new SelectList(_context.DonemDersler, "DonemDersId", "DonemDersId", obsOgrenciDonemDers.DonemDersId);
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler.Include(x => x.Ders), "DonemDersId", "DonemDersId", obsOgrenciDonemDers.DonemDersId);
            ViewData["OgrenciId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "Ad", obsOgrenciDonemDers.OgrenciId);
            return View(obsOgrenciDonemDers);
        }

        // GET: ObsOgrenciDonemDers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgrenciDonemDers = await _context.OgrenciDonemDersler
                .Include(o => o.DonemDers)
                .Include(o => o.Ogrenci)
                .FirstOrDefaultAsync(m => m.KayıtId == id);
            if (obsOgrenciDonemDers == null)
            {
                return NotFound();
            }

            return View(obsOgrenciDonemDers);
        }

        // POST: ObsOgrenciDonemDers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsOgrenciDonemDers = await _context.OgrenciDonemDersler.FindAsync(id);
            if(obsOgrenciDonemDers == null)
                return RedirectToAction(nameof(Index));
            _context.OgrenciDonemDersler.Remove(obsOgrenciDonemDers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObsOgrenciDonemDersExists(int id)
        {
            return _context.OgrenciDonemDersler.Any(e => e.KayıtId == id);
        }
    }
}
