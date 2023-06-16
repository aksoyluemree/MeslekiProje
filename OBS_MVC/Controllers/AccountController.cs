namespace OBS_MVC.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using OBS_MVC.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OBSContext _context;

        public AccountController(ILogger<HomeController> logger, OBSContext context)
        {
            _logger = logger;
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("login")]
        public IActionResult Login()
        {
            var userStr = HttpContext.Session.GetString("user");
            ObsKullanici user;
            if (userStr != null)
            {
                user = JsonConvert.DeserializeObject<ObsKullanici>(userStr);
                if (user.Turu == "Ogrenci")
                    return RedirectToAction("Index", "Ogrenci");
                else if (user.Turu == "OgretimGorevlisi")
                    return RedirectToAction("Index", "OgretimGorevlisi");
                else if (user.Turu == "Admin")
                    return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        [Route("login")]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnurl)
        {
            if (ModelState.IsValid)
            {
                var userStr = HttpContext.Session.GetString("user");
                ObsKullanici user = _context.Kullanicilar.FirstOrDefault(a => a.KimlikNo == model.TcNo && a.Sifre == model.Password);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("userId", user.KullaniciId);
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }));
                    if (user.Turu == "Ogrenci")
                        return RedirectToAction("Index", "Ogrenci");
                    else if (user.Turu == "OgretimGorevlisi")
                        return RedirectToAction("Index", "OgretimGorevlisi");
                    else if (user.Turu == "Admin")
                        return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.error = "Tc kimlik veya şifre yanlış!";
                }

            }
            return View(model);
        }


        [HttpGet("SifreDegistir")]
        public IActionResult SifreDegistir()
        {
            return View();
        }

        [HttpPost]
        [Route("SifreDegistir")]
        public ActionResult SifreDegistir(LoginModel model)
        {
            ObsKullanici user = null;
            if (ModelState.IsValid)
            {
                var sessionUser = JsonConvert.DeserializeObject<ObsKullanici>(HttpContext.Session.GetString("user"));
                if (sessionUser.KimlikNo != model.TcNo)
                {
                    ViewBag.error = "Tc kimlik yanlış!";
                    return RedirectToAction("SifreDegistir", "Account");
                }
                user = _context.Kullanicilar.FirstOrDefault(a => a.KimlikNo == model.TcNo);
                if (user != null)
                {
                    HttpContext.Session.SetInt32("userId", user.KullaniciId);
                    user.Sifre = model.Password;
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(user, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }));
                    _context.SaveChanges();
                }
                else
                {
                    ViewBag.error = "Tc kimlik veya şifre yanlış!";
                }
            }
            if (user == null)
                return RedirectToAction("Login", "Account");

            return RedirectToAction("Index", user.Turu);
        }

        //[Route("register")]
        //[HttpGet]
        //public IActionResult Register()
        //{
        //    return View();
        //}

        //[Route("register")]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Register(User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var found = _context.Users.FirstOrDefault(x => x.Email == user.Email);
        //        if (found == null)
        //        {
        //            user.Status = "Confirmation Waiting";
        //            user.CreatedDate = DateTime.Now;
        //            user.ApplicationDate = DateTime.Now;
        //            var userType = _context.UserTypes.FirstOrDefault(x => x.UserTypeName == "Audience");
        //            if (user.isVIP)
        //                user.Vipnumber = (new Random()).Next(1000000, 10000000).ToString();
        //            user.UserTypeId = userType?.UserTypeId;
        //            _context.Users.Add(user);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction("Login", "Account");
        //        }
        //        else
        //        {
        //            ViewBag.error = "EMail is already used!";
        //        }
        //    }
        //    return View();
        //}

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("user");
            return RedirectToAction("Login");
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
