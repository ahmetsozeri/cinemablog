using SinemaBiletOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SinemaBiletOtomasyonu.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult KayitOl()
        {
            List<SelectListItem> deger1 = (from x in c.Sehirs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.SehirAdi,
                                               Value = x.Plaka.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Musteri m)
        {
            c.Musteris.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public ActionResult MusteriLogin()
        {
            return View();

        }
        [HttpPost]
        public ActionResult MusteriLogin(Musteri m)
        {
            var bilgiler = c.Musteris.FirstOrDefault(x => x.ePosta == m.ePosta && x.Sifre == m.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.ePosta, false);
                Session["ePosta"] = bilgiler.ePosta.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {  
            return View();
            }
        }
    }
}