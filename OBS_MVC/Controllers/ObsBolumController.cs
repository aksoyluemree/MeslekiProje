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
    public class ObsBolumController : Controller
    {
        private readonly OBSContext _context;

        public ObsBolumController(OBSContext context)
        {
            _context = context;
        }

        // GET: ObsBolum
        public async Task<IActionResult> Index()
        {
            var oBSContext = _context.Bolumler.Include(o => o.Fakulte);
            return View(await oBSContext.ToListAsync());
        }

        // GET: ObsBolum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsBolum = await _context.Bolumler
                .Include(o => o.Fakulte)
                .FirstOrDefaultAsync(m => m.BolumId == id);
            if (obsBolum == null)
            {
                return NotFound();
            }

            return View(obsBolum);
        }

        // GET: ObsBolum/Create
        public IActionResult Create()
        {
            ViewData["FakulteId"] = new SelectList(_context.Fakulteler, "FakulteId", "Ad");
            return View();
        }

        // POST: ObsBolum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BolumId,Ad,Adres,Kod,FakulteId")] ObsBolum obsBolum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obsBolum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FakulteId"] = new SelectList(_context.Fakulteler, "FakulteId", "Ad", obsBolum.FakulteId);
            return View(obsBolum);
        }

        // GET: ObsBolum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsBolum = await _context.Bolumler.FindAsync(id);
            if (obsBolum == null)
            {
                return NotFound();
            }
            ViewData["FakulteId"] = new SelectList(_context.Fakulteler, "FakulteId", "Ad", obsBolum.FakulteId);
            return View(obsBolum);
        }

        // POST: ObsBolum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BolumId,Ad,Adres,Kod,FakulteId")] ObsBolum obsBolum)
        {
            if (id != obsBolum.BolumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obsBolum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsBolumExists(obsBolum.BolumId))
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
            ViewData["FakulteId"] = new SelectList(_context.Fakulteler, "FakulteId", "Ad", obsBolum.FakulteId);
            return View(obsBolum);
        }

        // GET: ObsBolum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsBolum = await _context.Bolumler
                .Include(o => o.Fakulte)
                .FirstOrDefaultAsync(m => m.BolumId == id);
            if (obsBolum == null)
            {
                return NotFound();
            }

            return View(obsBolum);
        }

        // POST: ObsBolum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsBolum = await _context.Bolumler.FindAsync(id);
            _context.Bolumler.Remove(obsBolum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObsBolumExists(int id)
        {
            return _context.Bolumler.Any(e => e.BolumId == id);
        }
    }
}
