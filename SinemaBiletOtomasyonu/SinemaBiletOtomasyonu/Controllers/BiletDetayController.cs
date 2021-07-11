using SinemaBiletOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinemaBiletOtomasyonu.Controllers
{
    public class BiletDetayController : Controller
    {
        // GET: BiletDetay
        Context c = new Context();
     
        public ActionResult Index()
        {
            
            var degerler = c.Koltuks.ToList();
            return View(degerler);

            //Class2 cs = new Class2();
            //cs.Deger6 = c.Koltuks.Where(x => x.KoltukID == id).ToList();
            //cs.Deger3 = c.Salons.Where(x => x == id).ToList();
            //cs.Deger4 = c.Sinemas.Where(x => x.FilmSalonSinemas == id).ToList();
            //cs.Deger5 = c.Films.Where(x => x.FilmSalonSinemas == id).ToList();

            //return View(cs);
        }

        public PartialViewResult Partial4()
        {

            List<SelectListItem> deger1 = (from x in c.Sinemas.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.SinemaAdi,
                                               Value = x.SinemaID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return PartialView("Partial4");
        }
        public PartialViewResult Partial5()
        {

            List<SelectListItem> deger1 = (from x in c.Salons.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.SalonAdi,
                                               Value = x.SalonID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return PartialView("Partial5");
        }
        public PartialViewResult Partial6()
        {

            List<SelectListItem> deger1 = (from x in c.Seans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Saat.ToString(),
                                               Value = x.SeansID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return PartialView("Partial6");
        }
        public PartialViewResult Partial7()
        {

            List<SelectListItem> deger1 = (from x in c.Films.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.FilmAdi.ToString(),
                                               Value = x.FilmID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;

            return PartialView("Partial7");
        }

    }
}