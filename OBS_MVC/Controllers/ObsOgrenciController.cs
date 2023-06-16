using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OBS_MVC.Models;

namespace OBS_MVC.Controllers
{
    public class ObsOgrenciController : Controller
    {
        private readonly OBSContext _context;

        public ObsOgrenciController(OBSContext context)
        {
            _context = context;
        }

        // GET: ObsOgrenci
        public async Task<IActionResult> Index()
        {
            var oBSContext = _context.Ogrenciler.Include(o => o.Bolum).Include(o => o.Kullanici);
            return View(await oBSContext.ToListAsync());
        }

        // GET: ObsOgrenci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgrenci = await _context.Ogrenciler
                .Include(o => o.Bolum)
                .Include(o => o.Kullanici)
                .FirstOrDefaultAsync(m => m.OgrenciId == id);
            if (obsOgrenci == null)
            {
                return NotFound();
            }

            return View(obsOgrenci);
        }

        // GET: ObsOgrenci/Create
        public IActionResult Create()
        {
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "Ad");
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciAdi");
            return View();
        }

        // POST: ObsOgrenci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OgrenciId,Ad,Soyad,KimlikNo,Eposta,DogumTarih,GirisTarih,BolumId,KullaniciId")] ObsOgrenci obsOgrenci)
        {
            if (ModelState.IsValid)
            {
                if (Request?.Form?.Files.Count > 0)
                {
                    var file = Request?.Form?.Files?[0];
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    obsOgrenci.Resim = ms.ToArray();

                    ms.Close();
                    ms.Dispose();
                }
                _context.Add(obsOgrenci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "Ad", obsOgrenci.BolumId);
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciAdi", obsOgrenci.KullaniciId);
            return View(obsOgrenci);
        }

        // GET: ObsOgrenci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgrenci = await _context.Ogrenciler.FindAsync(id);
            if (obsOgrenci == null)
            {
                return NotFound();
            }
            if (obsOgrenci.Resim?.Length > 0)
            {
                string imageBase64Data = Convert.ToBase64String(obsOgrenci.Resim);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                ViewBag.ImageDataUrl = imageDataURL;
            }
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "Ad", obsOgrenci.BolumId);
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciAdi", obsOgrenci.KullaniciId);
            return View(obsOgrenci);
        }

        // POST: ObsOgrenci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OgrenciId,Ad,Soyad,KimlikNo,Eposta,DogumTarih,GirisTarih,BolumId,KullaniciId,Resim")] ObsOgrenci obsOgrenci)
        {
            if (id != obsOgrenci.OgrenciId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Request?.Form?.Files.Count > 0)
                    {
                        var file = Request?.Form?.Files?[0];
                        MemoryStream ms = new MemoryStream();
                        file.CopyTo(ms);
                        obsOgrenci.Resim = ms.ToArray();

                        ms.Close();
                        ms.Dispose();
                    }
                    _context.Update(obsOgrenci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsOgrenciExists(obsOgrenci.OgrenciId))
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
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "Ad", obsOgrenci.BolumId);
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciAdi", obsOgrenci.KullaniciId);
            return View(obsOgrenci);
        }

        // GET: ObsOgrenci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgrenci = await _context.Ogrenciler
                .Include(o => o.Bolum)
                .Include(o => o.Kullanici)
                .Include(o => o.OgrenciDonemDersleri)
                .FirstOrDefaultAsync(m => m.OgrenciId == id);
            if (obsOgrenci == null)
            {
                return NotFound();
            }

            return View(obsOgrenci);
        }

        // POST: ObsOgrenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var obsOgrenci = await _context.Ogrenciler.FindAsync(id);
                _context.Ogrenciler.Remove(obsOgrenci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ObsOgrenciExists(int id)
        {
            return _context.Ogrenciler.Any(e => e.OgrenciId == id);
        }
    }
}
