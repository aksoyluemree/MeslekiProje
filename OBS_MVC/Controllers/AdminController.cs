namespace OBS_MVC.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OBS_MVC.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AdminController : Controller
    {
        private readonly OBSContext _context;

        public AdminController(OBSContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32("userId");
            ObsKullanici user = new ObsKullanici();
            if (userId != null)
                user = _context.Kullanicilar.Find(userId);
            return View(user);
        }
    }
}
