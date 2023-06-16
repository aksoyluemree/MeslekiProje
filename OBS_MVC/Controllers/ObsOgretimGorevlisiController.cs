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
    public class ObsOgretimGorevlisiController : Controller
    {
        private readonly OBSContext _context;

        public ObsOgretimGorevlisiController(OBSContext context)
        {
            _context = context;
        }

        // GET: ObsOgretimGorevlisi
        public async Task<IActionResult> Index()
        {
            var oBSContext = _context.OgretimGorevlileri.Include(o => o.DonemDersleri).Include(o => o.Bolum);
            return View(await oBSContext.ToListAsync());
        }

        // GET: ObsOgretimGorevlisi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgretimGorevlisi = await _context.OgretimGorevlileri
                .Include(o => o.DonemDersleri)
                .Include(o => o.Bolum)
                .Include(o => o.Kullanici)
                .FirstOrDefaultAsync(m => m.OgretimGorevlisiId == id);
            if (obsOgretimGorevlisi == null)
            {
                return NotFound();
            }

            return View(obsOgretimGorevlisi);
        }

        // GET: ObsOgretimGorevlisi/Create
        public IActionResult Create()
        {
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "BolumId");
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciAdi");
            return View();
        }

        // POST: ObsOgretimGorevlisi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ad,Soyad,KimlikNo,Eposta,DogumTarih,GirisTarih,BolumId,KullaniciId")] ObsOgretimGorevlisi obsOgretimGorevlisi)
        {
            if (ModelState.IsValid)
            {
                if (Request?.Form?.Files.Count > 0)
                {
                    var file = Request?.Form?.Files?[0];
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    obsOgretimGorevlisi.Resim = ms.ToArray();

                    ms.Close();
                    ms.Dispose();
                }
                _context.Add(obsOgretimGorevlisi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "BolumId", obsOgretimGorevlisi.BolumId);
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciAdi", obsOgretimGorevlisi.KullaniciId);
            return View(obsOgretimGorevlisi);
        }

        // GET: ObsOgretimGorevlisi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgretimGorevlisi = await _context.OgretimGorevlileri.FindAsync(id);
            if (obsOgretimGorevlisi == null)
            {
                return NotFound();
            }
            if (obsOgretimGorevlisi.Resim?.Length > 0)
            {
                string imageBase64Data = Convert.ToBase64String(obsOgretimGorevlisi.Resim);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                ViewBag.ImageDataUrl = imageDataURL;
            }
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "BolumId", obsOgretimGorevlisi.BolumId);
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciAdi", obsOgretimGorevlisi.KullaniciId);
            return View(obsOgretimGorevlisi);
        }

        // POST: ObsOgretimGorevlisi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OgretimGorevlisiId,Ad,Soyad,KimlikNo,Eposta,DogumTarih,GirisTarih,BolumId,KullaniciId,Resim")] ObsOgretimGorevlisi obsOgretimGorevlisi)
        {
            if (id != obsOgretimGorevlisi.OgretimGorevlisiId)
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
                        obsOgretimGorevlisi.Resim = ms.ToArray();

                        ms.Close();
                        ms.Dispose();
                    }
                    _context.Update(obsOgretimGorevlisi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsOgretimGorevlisiExists(obsOgretimGorevlisi.OgretimGorevlisiId))
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
            ViewData["BolumId"] = new SelectList(_context.Bolumler, "BolumId", "BolumId", obsOgretimGorevlisi.BolumId);
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "KullaniciId", "KullaniciAdi", obsOgretimGorevlisi.KullaniciId);

            return View(obsOgretimGorevlisi);
        }

        // GET: ObsOgretimGorevlisi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var obsOgretimGorevlisi = await _context.OgretimGorevlileri
                .Include(o => o.Bolum)
                .Include(o => o.Kullanici)
                .Include(o => o.DonemDersleri)
                .Include(o => o.OgretimGorevlisiDersleri)
                .FirstOrDefaultAsync(m => m.OgretimGorevlisiId == id);

            if (obsOgretimGorevlisi == null)
            {
                return NotFound();
            }

            return View(obsOgretimGorevlisi);
        }

        // POST: ObsOgretimGorevlisi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsOgretimGorevlisi = await _context.OgretimGorevlileri.FindAsync(id);
            try
            {
                _context.OgretimGorevlileri.Remove(obsOgretimGorevlisi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return RedirectToAction(nameof(Index), obsOgretimGorevlisi);
        }

        private bool ObsOgretimGorevlisiExists(int id)
        {
            return _context.OgretimGorevlileri.Any(e => e.OgretimGorevlisiId == id);
        }
    }
}
