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
    public class ObsSinavTarihController : Controller
    {
        private readonly OBSContext _context;

        public ObsSinavTarihController(OBSContext context)
        {
            _context = context;
        }

        // GET: ObsSinavTarih
        public async Task<IActionResult> Index()
        {
            var oBSContext = _context.SinavTarihleri.Include(o => o.DonemDers);
            return View(await oBSContext.ToListAsync());
        }

        // GET: ObsSinavTarih/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsSinavTarih = await _context.SinavTarihleri
                .Include(o => o.DonemDers)
                .FirstOrDefaultAsync(m => m.SinavId == id);
            if (obsSinavTarih == null)
            {
                return NotFound();
            }

            return View(obsSinavTarih);
        }

        // GET: ObsSinavTarih/Create
        public IActionResult Create()
        {
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler, "DonemDersId", "DonemDersId");
            return View();
        }

        // POST: ObsSinavTarih/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SinavId,SinavTur,SinavTarih,DonemDersId")] ObsSinavTarih obsSinavTarih)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obsSinavTarih);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler, "DonemDersId", "DonemDersId", obsSinavTarih.DonemDersId);
            return View(obsSinavTarih);
        }

        // GET: ObsSinavTarih/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsSinavTarih = await _context.SinavTarihleri.FindAsync(id);
            if (obsSinavTarih == null)
            {
                return NotFound();
            }
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler, "DonemDersId", "DonemDersId", obsSinavTarih.DonemDersId);
            return View(obsSinavTarih);
        }

        // POST: ObsSinavTarih/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SinavId,SinavTur,SinavTarih,DonemDersId")] ObsSinavTarih obsSinavTarih)
        {
            if (id != obsSinavTarih.SinavId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obsSinavTarih);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsSinavTarihExists(obsSinavTarih.SinavId))
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
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler, "DonemDersId", "DonemDersId", obsSinavTarih.DonemDersId);
            return View(obsSinavTarih);
        }

        // GET: ObsSinavTarih/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsSinavTarih = await _context.SinavTarihleri
                .Include(o => o.DonemDers)
                .FirstOrDefaultAsync(m => m.SinavId == id);
            if (obsSinavTarih == null)
            {
                return NotFound();
            }

            return View(obsSinavTarih);
        }

        // POST: ObsSinavTarih/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsSinavTarih = await _context.SinavTarihleri.FindAsync(id);
            _context.SinavTarihleri.Remove(obsSinavTarih);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObsSinavTarihExists(int id)
        {
            return _context.SinavTarihleri.Any(e => e.SinavId == id);
        }
    }
}
