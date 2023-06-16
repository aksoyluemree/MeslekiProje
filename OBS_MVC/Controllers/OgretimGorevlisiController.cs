namespace OBS_MVC.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using OBS_MVC.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OgretimGorevlisiController : Controller
    {
        private readonly OBSContext _context;

        public OgretimGorevlisiController(OBSContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            ObsOgretimGorevlisi user = new ObsOgretimGorevlisi();
            if (userId != null)
                user = _context.OgretimGorevlileri.Include(x => x.Bolum).FirstOrDefault(x => x.KullaniciId == userId);
            if (user == null)
                return RedirectToAction("Login", "Account");

            if (user.Resim?.Length > 0)
            {
                string imageBase64Data = Convert.ToBase64String(user.Resim);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                ViewBag.ImageDataUrl = imageDataURL;
            }
            HttpContext.Session.SetInt32("ogretmenId", user.OgretimGorevlisiId);
            return View(user);
        }


        [HttpGet("DonemDers")]
        public IActionResult DonemDers()
        {
            var ogretmenId = HttpContext.Session.GetInt32("ogretmenId");
            List<ObsDonemDers> dersler;
            dersler = _context.DonemDersler.Include(x => x.Ders).Where(x => x.OgretimGorevlisiId == ogretmenId).ToList();
            return View(dersler);
        }


        public async Task<IActionResult> DersOgrenciListesi(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDersOgrenciListesi = await _context.OgrenciDonemDersler
                .Include(o => o.Ogrenci)
                .Include(o => o.DonemDers).ThenInclude(d=>d.Ders)
                .Where(m => m.DonemDersId == id).ToListAsync();
            
            if (obsDersOgrenciListesi == null)
            {
                return NotFound();
            }

            return View(obsDersOgrenciListesi);
        }

        public async Task<IActionResult> DonemDersDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDonemDers = await _context.DonemDersler
                .Include(o => o.Ders)
                .Include(o => o.Donem)
                .Include(o => o.OgretimGorevlisi)
                .FirstOrDefaultAsync(m => m.DonemDersId == id);
            if (obsDonemDers == null)
            {
                return NotFound();
            }

            return View(obsDonemDers);
        }

        // GET: ObsDonemDers/Create
        public IActionResult CreateDonemDers()
        {
            ViewData["DersId"] = new SelectList(_context.Dersler, "DersId", "Ad");
            ViewData["DonemId"] = new SelectList(_context.Donemler, "DonemId", "DonemId");
            ViewData["OgretimGorevlisiId"] = new SelectList(_context.OgretimGorevlileri, "OgretimGorevlisiId", "Ad");
            return View();
        }

        // POST: ObsDonemDers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDonemDers([Bind("DonemDersId,DonemId,DersId,OgretimGorevlisiId")] ObsDonemDers obsDonemDers)
        {

            var ogretmenId = HttpContext.Session.GetInt32("ogretmenId");
            if (ogretmenId == null)
                return RedirectToAction(nameof(DonemDers));
            obsDonemDers.OgretimGorevlisiId = ogretmenId.Value;
            if (ModelState.IsValid)
            {
                _context.Add(obsDonemDers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DersId"] = new SelectList(_context.Dersler, "DersId", "Ad", obsDonemDers.DersId);
            ViewData["DonemId"] = new SelectList(_context.Donemler, "DonemId", "DonemId", obsDonemDers.DonemId);
            ViewData["OgretimGorevlisiId"] = new SelectList(_context.OgretimGorevlileri, "OgretimGorevlisiId", "Ad", obsDonemDers.OgretimGorevlisiId);
            return View(obsDonemDers);
        }

        // GET: ObsDonemDers/Delete/5
        public async Task<IActionResult> DeleteDonemDers(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsDonemDers = await _context.DonemDersler
                .Include(o => o.Ders)
                .Include(o => o.Donem)
                .Include(o => o.OgretimGorevlisi)
                .Include(o => o.OgretimGorevlisiDers)
                .FirstOrDefaultAsync(m => m.DonemDersId == id);
            if (obsDonemDers == null)
            {
                return NotFound();
            }

            return View(obsDonemDers);
        }

        // POST: ObsDonemDers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obsDonemDers = await _context.DonemDersler.FindAsync(id);
            _context.DonemDersler.Remove(obsDonemDers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObsDonemDersExists(int id)
        {
            return _context.DonemDersler.Any(e => e.DonemDersId == id);
        }

        //OgrenciDersEdit/5
        public async Task<IActionResult> OgrenciDersEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obsOgrenciDonemDers = await _context.OgrenciDonemDersler
                .Include(o=>o.Ogrenci)
                .Include(d=>d.DonemDers).ThenInclude(r=>r.Ders)
                .FirstOrDefaultAsync(x=>x.KayıtId == id);
            if (obsOgrenciDonemDers == null)
            {
                return NotFound();
            }
            //ViewData["DersId"] = new SelectList(_context.Dersler, "DersId", "Ad", obsOgrenciDonemDers.DersId);
            //ViewData["DonemId"] = new SelectList(_context.Donemler, "DonemId", "DonemId", obsOgrenciDonemDers.DonemId);
            //ViewData["OgretimGorevlisiId"] = new SelectList(_context.OgretimGorevlileri, "OgretimGorevlisiId", "Ad", obsOgrenciDonemDers.OgretimGorevlisiId);
            return View(obsOgrenciDonemDers);
        }

        // POST: ObsDonemDers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OgrenciDersEdit(int id, [Bind("KayıtId,DonemDersId,OgrenciId,Vize1,Vize2,FinalNot,Ortalama,BasariDurumTip")] ObsOgrenciDonemDers obsOgrenciDonemDers)
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
                    return NotFound();
                }
                return RedirectToAction(nameof(DersOgrenciListesi), new { id = obsOgrenciDonemDers.DonemDersId });
            }
            //ViewData["DersId"] = new SelectList(_context.Dersler, "DersId", "Ad", obsOgrenciDonemDers.DersId);
            //ViewData["DonemId"] = new SelectList(_context.Donemler, "DonemId", "DonemId", obsOgrenciDonemDers.DonemId);
            //ViewData["OgretimGorevlisiId"] = new SelectList(_context.OgretimGorevlileri, "OgretimGorevlisiId", "Ad", obsOgrenciDonemDers.OgretimGorevlisiId);
            return View(obsOgrenciDonemDers);
        }

    }
}
