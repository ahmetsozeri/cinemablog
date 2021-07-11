using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SinemaBiletOtomasyonu.Models.Siniflar;
using PagedList;

namespace SinemaBiletOtomasyonu.Controllers
{
    public class HaberController : Controller
    {
        Context c = new Context();
        // GET: Haber
        public ActionResult Index(int page = 1) //Anasayfa
        {
            var degerler = c.Habers.ToList().ToPagedList(page, 12);
            return View(degerler);
        }
        [Authorize]
        public ActionResult Index2(string option, string search, int page = 1) //Admin
        {

            if (option == "id")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(c.Habers.Where(x => x.id.ToString() == search || search == null).ToList().ToPagedList(page, 10));
            }
            else if (option == "PostedDate")
            {
                return View(c.Habers.Where(x => x.PostedDate.ToString() == search || search == null).ToList().ToPagedList(page, 10));

            }
            else if (option == "Title")
            {
                return View(c.Habers.Where(x => x.Title.ToString() == search || search == null).ToList().ToPagedList(page, 10));

            }
            else
            {
                return View(c.Habers.ToList().ToPagedList(page, 10));

            }
        }

        [HttpPost]
        public JsonResult UploadFile(HttpPostedFileBase uploadedFiles)
        {
            string returnImagePath = string.Empty;
            string fileName;
            string Extension;
            string imageName;
            string imageSavePath;

            if (uploadedFiles.ContentLength > 0)
            {
                fileName = Path.GetFileNameWithoutExtension(uploadedFiles.FileName);
                Extension = Path.GetExtension(uploadedFiles.FileName);
                imageName = fileName + DateTime.Now.ToString("yyyyMMddHHmmss");
                imageSavePath = Server.MapPath("/postedImage/") + imageName + Extension;

                uploadedFiles.SaveAs(imageSavePath);
                returnImagePath = "/postedImage/" + imageName + Extension;
            }

            return Json(Convert.ToString(returnImagePath), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniHaber()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult YeniHaber(Haber hbr)
        {

            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                hbr.KucukResim = "/images/" + dosyaadi + uzanti;
            }

            c.Habers.Add(hbr);
            c.SaveChanges();
            return View();

        }

        public ActionResult HaberSil(int id)
        {
            var tur = c.Habers.Find(id);
            c.Habers.Remove(tur);
            c.SaveChanges();
            return RedirectToAction("Index2");
        }

        public ActionResult HaberGetir(int id)
        {

            var flm = c.Habers.Find(id);

            var dgr2 = c.Habers.Find(id);
            ViewBag.dgr2 = dgr2.KucukResim;
            return View("HaberGetir", flm);
        }
        public ActionResult HaberGuncelle(Haber k)
        {
            if (!ModelState.IsValid)
            {
                return View("HaberGetir");
            }
            try
            {
                if (Request.Files.Count > 0)
                {
                    string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                    string uzanti = Path.GetExtension(Request.Files[0].FileName);
                    string yol = "~/images/" + dosyaadi + uzanti;
                    Request.Files[0].SaveAs(Server.MapPath(yol));
                    k.KucukResim = "/images/" + dosyaadi + uzanti;
                }
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                var f = c.Habers.Find(k.id);
                f.Title = k.Title;
                f.Metatitle = k.Metatitle;
                f.Shortinfo = k.Shortinfo;
                f.İcerik = k.İcerik;
                f.PostedDate = k.PostedDate;
                f.Active = k.Active;
                f.KucukResim = k.KucukResim;

                c.SaveChanges();
                return RedirectToAction("Index2");
            }
            var fm = c.Habers.Find(k.id);
            fm.Title = k.Title;
            fm.Metatitle = k.Metatitle;
            fm.Shortinfo = k.Shortinfo;
            fm.İcerik = k.İcerik;
            fm.PostedDate = k.PostedDate;
            fm.Active = k.Active;
            fm.KucukResim = k.KucukResim;
            c.SaveChanges();
            return RedirectToAction("Index2");

        }

    }
}