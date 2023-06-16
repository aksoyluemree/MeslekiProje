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

    public class OgrenciController : Controller
    {
        private readonly OBSContext _context;

        public OgrenciController(OBSContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            ObsOgrenci user = new ObsOgrenci();
            if (userId != null)
                user = _context.Ogrenciler.Include(x => x.Bolum).FirstOrDefault(x => x.KullaniciId == userId);
            if (user == null)
                return RedirectToAction("Login", "Account");
            if (user.Resim?.Length > 0)
            {
                string imageBase64Data = Convert.ToBase64String(user.Resim);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                ViewBag.ImageDataUrl = imageDataURL;
            }
            HttpContext.Session.SetInt32("ogrenciId", user.OgrenciId);
            return View(user);
        }

        //[HttpGet("DonemDersler")]
        //public IActionResult DonemDersler()
        //{
        //    var ogrenciId = HttpContext.Session.GetInt32("ogrenciId");
        //    List<ObsOgrenciDonemDers> dersler;
        //    dersler = _context.OgrenciDonemDersler.Include(x=>x.DonemDers).ThenInclude(y=>y.Ders).Where(x=>x.OgrenciId == ogrenciId).ToList();
        //    return View(dersler);
        //}

        [HttpGet("OgrenciDonemDers")]
        public IActionResult OgrenciDonemDers()
        {
            var ogrenciId = HttpContext.Session.GetInt32("ogrenciId");
            List<ObsOgrenciDonemDers> dersler;
            dersler = _context.OgrenciDonemDersler.Include(x => x.DonemDers).ThenInclude(y => y.Ders).Where(x => x.OgrenciId == ogrenciId).ToList();
            return View(dersler);
        }

        // GET: ObsOgrenciDonemDers/Details/5
        public async Task<IActionResult> DonemDersDetails(int? id)
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
        public IActionResult CreateOgrenciDonemDers()
        {
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler.Include(x => x.Ders), "DonemDersId", "DonemDersId");
            //ViewData["OgrenciId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "Ad");

            return View();
        }

        // POST: ObsOgrenciDonemDers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOgrenciDonemDers([Bind("KayıtId,DonemDersId,OgrenciId,Vize1,Vize2,FinalNot,Ortalama,BasariDurumTip")] ObsOgrenciDonemDers obsOgrenciDonemDers)
        {
            var ogrenciId = HttpContext.Session.GetInt32("ogrenciId");
            if (ogrenciId == null)
                return RedirectToAction(nameof(OgrenciDonemDers));
            obsOgrenciDonemDers.OgrenciId = ogrenciId.Value;
            if (ModelState.IsValid)
            {
                _context.Add(obsOgrenciDonemDers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(OgrenciDonemDers));
            }
            ViewData["DonemDersId"] = new SelectList(_context.DonemDersler, "DonemDersId", "DonemDersId", obsOgrenciDonemDers.DonemDersId);
            ViewData["OgrenciId"] = new SelectList(_context.Ogrenciler, "OgrenciId", "Ad", obsOgrenciDonemDers.OgrenciId);
            return View(obsOgrenciDonemDers);
        }

        public async Task<IActionResult> DeleteDonemDers(int? id)
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
            _context.OgrenciDonemDersler.Remove(obsOgrenciDonemDers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(OgrenciDonemDers));
        }

        private bool ObsOgrenciDonemDersExists(int id)
        {
            return _context.OgrenciDonemDersler.Any(e => e.KayıtId == id);
        }

    }
}
