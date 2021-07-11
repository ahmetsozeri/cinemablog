using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SinemaBiletOtomasyonu.Models.Siniflar;

namespace SinemaBiletOtomasyonu.Controllers
{
    public class MusteriController : Controller
    {
        Context c = new Context();
        // GET: Musteri
        public ActionResult Index(string option, string search, int page = 1)
        {
            if (option == "Telefon")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(c.Musteris.Where(x => x.Telefon.ToString() == search || search == null).ToList().ToPagedList(page, 10));
            }
            else if (option == "ePosta")
            {
                return View(c.Musteris.Where(x => x.ePosta == search || search == null).ToList().ToPagedList(page, 10));
                
            }
            else
            {
                return View(c.Musteris.ToList().ToPagedList(page, 10));

            }
        }
        [HttpGet]
        public ActionResult MusteriEkle()
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
        public ActionResult MusteriEkle(Musteri m)
        {
            c.Musteris.Add(m);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(int id)
        {
            var tur = c.Musteris.Find(id);
            c.Musteris.Remove(tur);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Sehirs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.SehirAdi,
                                               Value = x.Plaka.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var flm = c.Musteris.Find(id);
            return View("MusteriGetir", flm);
        }
        public ActionResult MusteriGuncelle(Musteri k)
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
            return RedirectToAction("Index");
        }
    }
}