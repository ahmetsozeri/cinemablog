using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinemaBiletOtomasyonu.Models.Siniflar;


namespace SinemaBiletOtomasyonu.Controllers
{
    public class FilmTurController : Controller
    {
        Context c = new Context();

        // GET: FilmTur
        
        public ActionResult Index()
        {
            var degerler = c.FilmTurs.ToList();
            return View(degerler);
           
        }
        [HttpGet]
        public ActionResult FilmTurEkle()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult FilmTurEkle(FilmTur t)
        {
            var maxID = c.FilmTurs.OrderByDescending(c => c.TurID).FirstOrDefault();
            t.TurID = Convert.ToInt32(maxID) + 1;          
            c.FilmTurs.Add(t);
            c.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult FilmTurSil(int id)
        {
            var tur = c.FilmTurs.Find(id);
            c.FilmTurs.Remove(tur);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FilmTurGetir(int id)
        {
            var tur = c.FilmTurs.Find(id);
            return View("FilmTurGetir", tur);
        }
        public ActionResult TurGuncelle(FilmTur k)
        {
            var tur = c.FilmTurs.Find(k.TurID);
            tur.TurAdi = k.TurAdi;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}