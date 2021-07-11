using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SinemaBiletOtomasyonu.Models.Siniflar;
namespace SinemaBiletOtomasyonu.Controllers
{
    public class HomeController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Films.ToList();
            return View(degerler);
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

        public ActionResult Profil()
        {
            return View();
        }

        public PartialViewResult Partial3()
        {

            var mail = (string)Session["ePosta"];
            var id = c.Musteris.Where(x=>x.ePosta==mail).Select(y=>y.MusteriID).FirstOrDefault();
            var musteribul = c.Musteris.Find(id);
            List<SelectListItem> deger1 = (from x in c.Sehirs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.SehirAdi,
                                               Value = x.Plaka.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return PartialView("Partial3",musteribul);
        }

        public ActionResult ProfilGuncelle(Musteri k)
        {
            var fl = c.Musteris.Find(k.MusteriID);
            fl.MusteriAd = k.MusteriAd;
            fl.MusteriSoyad = k.MusteriSoyad;
            fl.KullaniciAdi = k.KullaniciAdi;
            fl.Sifre = k.Sifre;
            fl.Plaka = k.Plaka;
            fl.Adres = k.Adres;
            fl.Telefon = k.Telefon;
            fl.ePosta = k.ePosta;
            c.SaveChanges();
            return RedirectToAction("Profil","Home");
        }

        public ActionResult Sosyal()
        {
            return View();
        }

        public ActionResult Hakkimizda()
        {
            return View();
        }

        public ActionResult Iletisim()
        {
            return View();
        } 
        public ActionResult Yardim()
        {

            return View();
        }

        public ActionResult HomeLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}