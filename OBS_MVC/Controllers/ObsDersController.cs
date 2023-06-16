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
    public class ObsDersController : Controller
    {
        private readonly OBSContext _context;

        public ObsDersController(OBSContext context)
        {
            _context = context;
        }

        // GET: ObsDers
        public async Task<IActionResult> Index()
        {
            var oBSContext = _context.Dersler.Include(o => o.Bolum);
            return View(await oBSContext.ToListAsync());
        }

        // GET: ObsDers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDers = await _context.Dersler
                .Include(o => o.Bolum)
                .FirstOrDefaultAsync(m => m.DersId == id);
            if (obsDers == null)
            {
                return NotFound();
            }

            return View(obsDers);
        }

        // GET: ObsDers/Create
        public IActionResult Create()
        {
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "Ad");
            return View();
        }

        // POST: ObsDers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DersId,Ad,Kod,BolumId")] ObsDers obsDers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obsDers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "Ad", obsDers.BolumId);
            return View(obsDers);
        }

        // GET: ObsDers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDers = await _context.Dersler.FindAsync(id);
            if (obsDers == null)
            {
                return NotFound();
            }
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "Ad", obsDers.BolumId);
            return View(obsDers);
        }

        // POST: ObsDers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DersId,Ad,Kod,BolumId")] ObsDers obsDers)
        {
            if (id != obsDers.DersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obsDers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsDersExists(obsDers.DersId))
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
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "Ad", obsDers.BolumId);
            return View(obsDers);
        }

        // GET: ObsDers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDers = await _context.Dersler
                .Include(o => o.Bolum)
                .FirstOrDefaultAsync(m => m.DersId == id);
            if (obsDers == null)
            {
                return NotFound();
            }

            return View(obsDers);
        }

        // POST: ObsDers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsDers = await _context.Dersler.FindAsync(id);
            _context.Dersler.Remove(obsDers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObsDersExists(int id)
        {
            return _context.Dersler.Any(e => e.DersId == id);
        }
    }
}
