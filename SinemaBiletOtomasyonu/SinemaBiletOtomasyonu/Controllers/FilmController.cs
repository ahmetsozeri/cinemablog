using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SinemaBiletOtomasyonu.Models.Siniflar;

namespace SinemaBiletOtomasyonu.Controllers
{
    public class FilmController : Controller
    {
        Context c = new Context();
        // GET: Film
        public ActionResult Index(string option, string search, int page = 1) /*admin görünecek kısım*/
        {
            if (option == "FilmAdi")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(c.Films.Where(x => x.FilmAdi == search || search == null).ToList().ToPagedList(page, 10));
            }
            else if (option == "FilmTur.TurAdi")
            {
                return View(c.Films.Where(x => x.FilmTur.TurAdi == search || search == null).ToList().ToPagedList(page, 10));

            }
            else
            {
                return View(c.Films.ToList().ToPagedList(page, 10));

            }
        }
        public ActionResult Index2() /*Admin panelinde görünecek kısım*/
        {
            var degerler = c.Films.ToList();
            return View(degerler);
        }
        //[HttpPost]
        //public JsonResult UploadFile(HttpPostedFileBase uploadedFiles)
        //{
        //    string returnImagePath = string.Empty;
        //    string fileName;
        //    string Extension;
        //    string imageName;
        //    string imageSavePath;

        //    if (uploadedFiles.ContentLength > 0)
        //    {
        //        fileName = Path.GetFileNameWithoutExtension(uploadedFiles.FileName);
        //        Extension = Path.GetExtension(uploadedFiles.FileName);
        //        imageName = fileName + DateTime.Now.ToString("yyyyMMddHHmmss");
        //        imageSavePath = Server.MapPath("/images/") + imageName + Extension;

        //        uploadedFiles.SaveAs(imageSavePath);
        //        returnImagePath = "/images/" + imageName + Extension;
        //    }

        //    return Json(Convert.ToString(returnImagePath), JsonRequestBehavior.AllowGet);
        //}
        [Authorize]
        [HttpGet]
        public ActionResult FilmEkle()
        {
            List<SelectListItem> deger1 = (from x in c.FilmTurs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.TurAdi,
                                               Value = x.TurID.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult FilmEkle(Film f)
        {

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                f.Afis = "/images/" + dosyaadi + uzanti;
            }
            c.Films.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult FilmSil(int id)
        {
            var tur = c.Films.Find(id);
            c.Films.Remove(tur);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult FilmGetir(int id)
        {


            List<SelectListItem> deger1 = (from x in c.FilmTurs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.TurAdi,
                                               Value = x.TurID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var flm = c.Films.Find(id);

            var dgr2 = c.Films.Find(id);
            ViewBag.dgr2 = dgr2.Afis;
            return View("FilmGetir", flm);
        }
        public ActionResult FilmGuncelle(Film k)
        {
            if (!ModelState.IsValid)
            {
                return View("FilmGetir");
            }
            try
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/images/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    k.Afis = "/images/" + dosyaadi + uzanti;
                }
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                var f = c.Films.Find(k.FilmID);
                f.FilmAdi = k.FilmAdi;
                f.FilmSuresi = k.FilmSuresi;
                f.TurID = k.TurID;
                f.Fiyat = k.Fiyat;
                f.Afis = k.Afis;
                f.KisaAciklama = k.KisaAciklama;
                f.Aciklama = k.Aciklama;
                c.SaveChanges();
                return RedirectToAction("Index");
            }
            var fl = c.Films.Find(k.FilmID);
            fl.FilmAdi = k.FilmAdi;
            fl.FilmSuresi = k.FilmSuresi;
            fl.TurID = k.TurID;
            fl.Fiyat = k.Fiyat;
            fl.Afis = k.Afis;
            fl.KisaAciklama = k.KisaAciklama;
            fl.Aciklama = k.Aciklama;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public PartialViewResult Partial1()
        {
            var sorgu = c.Salons.ToList();
            return PartialView(sorgu);
        }
    }
}