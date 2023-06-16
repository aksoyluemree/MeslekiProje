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
    public class ObsFakulteController : Controller
    {
        private readonly OBSContext _context;

        public ObsFakulteController(OBSContext context)
        {
            _context = context;
        }

        // GET: ObsFakulte
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fakulteler.ToListAsync());
        }

        // GET: ObsFakulte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsFakulte = await _context.Fakulteler
                .FirstOrDefaultAsync(m => m.FakulteId == id);
            if (obsFakulte == null)
            {
                return NotFound();
            }

            return View(obsFakulte);
        }

        // GET: ObsFakulte/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObsFakulte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FakulteId,Ad,Adres")] ObsFakulte obsFakulte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obsFakulte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obsFakulte);
        }

        // GET: ObsFakulte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsFakulte = await _context.Fakulteler.FindAsync(id);
            if (obsFakulte == null)
            {
                return NotFound();
            }
            return View(obsFakulte);
        }

        // POST: ObsFakulte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FakulteId,Ad,Adres")] ObsFakulte obsFakulte)
        {
            if (id != obsFakulte.FakulteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obsFakulte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsFakulteExists(obsFakulte.FakulteId))
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
            return View(obsFakulte);
        }

        // GET: ObsFakulte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsFakulte = await _context.Fakulteler
                .FirstOrDefaultAsync(m => m.FakulteId == id);
            if (obsFakulte == null)
            {
                return NotFound();
            }

            return View(obsFakulte);
        }

        // POST: ObsFakulte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsFakulte = await _context.Fakulteler.FindAsync(id);
            _context.Fakulteler.Remove(obsFakulte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObsFakulteExists(int id)
        {
            return _context.Fakulteler.Any(e => e.FakulteId == id);
        }
    }
}
