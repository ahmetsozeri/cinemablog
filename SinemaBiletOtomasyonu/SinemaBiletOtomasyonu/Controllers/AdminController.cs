using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SinemaBiletOtomasyonu.Models.Siniflar;

namespace SinemaBiletOtomasyonu.Controllers
{
    public class AdminController : Controller
    {
        Context c = new Context();
        // GET: Admin

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(Admin m)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.KullaniciAD == m.KullaniciAD && x.Sifre == m.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAD, false);
                Session["KullaniciAD"] = bilgiler.KullaniciAD.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login","Admin");
        }


    }
}