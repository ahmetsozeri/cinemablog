using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SinemaBiletOtomasyonu.Models.Siniflar;

namespace SinemaBiletOtomasyonu.Controllers
{
    public class SinemaController : Controller
    {
        Context c = new Context();

        // GET: Sinema
        public ActionResult Index(string option, string search, int page = 1)
        {
            if (option == "SinemaAdi")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(c.Sinemas.Where(x => x.SinemaAdi.ToString() == search || search == null).ToList().ToPagedList(page, 10));
            }
            else if (option == "Sehir.SehirAdi")
            {
                return View(c.Sinemas.Where(x => x.Sehir.SehirAdi == search || search == null).ToList().ToPagedList(page, 10));

            }
            else
            {
                return View(c.Sinemas.ToList().ToPagedList(page, 10));

            }
        }

        [HttpGet]
        public ActionResult SinemaEkle()
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
        public ActionResult SinemaEkle(Sinema s)
        {
            c.Sinemas.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SinemaSil(int id)
        {
            var tur = c.Sinemas.Find(id);
            c.Sinemas.Remove(tur);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SinemaGetir(int id)
        {


            List<SelectListItem> deger1 = (from x in c.Sehirs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.SehirAdi,
                                               Value = x.Plaka.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var flm = c.Sinemas.Find(id);
            return View("SinemaGetir", flm);
        }
        public ActionResult SinemaGuncelle(Sinema s)
        {
            
            var fl = c.Sinemas.Find(s.SinemaID);
            fl.SinemaAdi = s.SinemaAdi;
            fl.Plaka = s.Plaka;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
