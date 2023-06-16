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
    public class ObsKullaniciController : Controller
    {
        private readonly OBSContext _context;

        public ObsKullaniciController(OBSContext context)
        {
            _context = context;
        }

        // GET: ObsKullanicis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kullanicilar.ToListAsync());
        }

        // GET: ObsKullanicis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsKullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(m => m.KullaniciId == id);
            if (obsKullanici == null)
            {
                return NotFound();
            }

            return View(obsKullanici);
        }

        // GET: ObsKullanicis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ObsKullanicis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KullaniciId,KullaniciAdi,Sifre,KimlikNo,Turu")] ObsKullanici obsKullanici)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obsKullanici);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obsKullanici);
        }

        // GET: ObsKullanicis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsKullanici = await _context.Kullanicilar.FindAsync(id);
            if (obsKullanici == null)
            {
                return NotFound();
            }
            return View(obsKullanici);
        }


        // GET: ObsKullanicis/Edit/5
        public async Task<IActionResult> SifreDegistir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsKullanici = await _context.Kullanicilar.FindAsync(id);
            if (obsKullanici == null)
            {
                return NotFound();
            }
            return View(obsKullanici);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SifreDegistir(int id, [Bind("KullaniciId,KullaniciAdi,Sifre,KimlikNo,Turu")] ObsKullanici obsKullanici)
        {
            if (id != obsKullanici.KullaniciId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    obsKullanici = _context.Kullanicilar.FirstOrDefault(x => x.KullaniciId == obsKullanici.KullaniciId);
                    obsKullanici.Sifre = obsKullanici.Sifre;
                    _context.Update(obsKullanici);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsKullaniciExists(obsKullanici.KullaniciId))
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
            return View(obsKullanici);
        }


        // POST: ObsKullanicis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KullaniciId,KullaniciAdi,Sifre,KimlikNo,Turu")] ObsKullanici obsKullanici)
        {
            if (id != obsKullanici.KullaniciId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obsKullanici);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObsKullaniciExists(obsKullanici.KullaniciId))
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
            return View(obsKullanici);
        }

        // GET: ObsKullanicis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsKullanici = await _context.Kullanicilar
                .FirstOrDefaultAsync(m => m.KullaniciId == id);
            if (obsKullanici == null)
            {
                return NotFound();
            }

            return View(obsKullanici);
        }

        // POST: ObsKullanicis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsKullanici = await _context.Kullanicilar.FindAsync(id);
            _context.Kullanicilar.Remove(obsKullanici);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObsKullaniciExists(int id)
        {
            return _context.Kullanicilar.Any(e => e.KullaniciId == id);
        }
    }
}
