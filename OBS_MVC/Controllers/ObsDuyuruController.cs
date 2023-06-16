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
    public class ObsDuyuruController : Controller
    {
        private readonly OBSContext _context;

        public ObsDuyuruController(OBSContext context)
        {
            _context = context;
        }

        // GET: ObsDuyurus
        public async Task<IActionResult> Index()
        {
            var oBSContext = _context.Duyurular.Include(o => o.Bolum);
            return View(await oBSContext.ToListAsync());
        }

        // GET: ObsDuyurus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDuyuru = await _context.Duyurular
                .Include(o => o.Bolum)
                .FirstOrDefaultAsync(m => m.DuyuruId == id);
            if (obsDuyuru == null)
            {
                return NotFound();
            }

            return View(obsDuyuru);
        }

        // GET: ObsDuyurus/Create
        public IActionResult Create()
        {
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "Ad");
            return View();
        }

        // POST: ObsDuyurus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DuyuruId,Duyuru,BolumId")] ObsDuyuru obsDuyuru)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obsDuyuru);
                await _context.SaveChangesAsync();

                var url = Request.Scheme+"://" + Request.Host + "/ObsDuyuru/Details/" + obsDuyuru.DuyuruId;
                var content = obsDuyuru.Duyuru + Environment.NewLine + url;

                foreach (var ogrenci in _context.Ogrenciler.Where(x => x.BolumId == obsDuyuru.BolumId))
                {
                    MailSender.SendMail(ogrenci.Eposta,"Duyuru "+ obsDuyuru.DuyuruId.ToString(), content);
                }

                foreach (var ogretmen in _context.OgretimGorevlileri.Where(x=>x.BolumId == obsDuyuru.BolumId))
                {
                    MailSender.SendMail(ogretmen.Eposta, "Duyuru " + obsDuyuru.DuyuruId.ToString(), content);
                }
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "Ad", obsDuyuru.BolumId);
            return View(obsDuyuru);
        }

        // GET: ObsDuyurus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDuyuru = await _context.Duyurular.FindAsync(id);
            if (obsDuyuru == null)
            {
                return NotFound();
            }
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "Ad", obsDuyuru.BolumId);
            return View(obsDuyuru);
        }

        // POST: ObsDuyurus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DuyuruId,Duyuru,BolumId")] ObsDuyuru obsDuyuru)
        {
            if (id != obsDuyuru.DuyuruId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obsDuyuru);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsDuyuruExists(obsDuyuru.DuyuruId))
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
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "Ad", obsDuyuru.BolumId);
            return View(obsDuyuru);
        }

        // GET: ObsDuyurus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDuyuru = await _context.Duyurular
                .Include(o => o.Bolum)
                .FirstOrDefaultAsync(m => m.DuyuruId == id);
            if (obsDuyuru == null)
            {
                return NotFound();
            }

            return View(obsDuyuru);
        }

        // POST: ObsDuyurus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsDuyuru = await _context.Duyurular.FindAsync(id);
            _context.Duyurular.Remove(obsDuyuru);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObsDuyuruExists(int id)
        {
            return _context.Duyurular.Any(e => e.DuyuruId == id);
        }
    }
}
