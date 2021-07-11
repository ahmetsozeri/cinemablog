using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using SinemaBiletOtomasyonu.Models.Siniflar;

namespace SinemaBiletOtomasyonu.Controllers
{
    public class SehirController : Controller
    {
        Context c = new Context();
        // GET: Sehir
        public ActionResult Index(string option, string search, int page=1)
        {
            if (option == "Plaka")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(c.Sehirs.Where(x => x.Plaka.ToString() == search || search == null).ToList().ToPagedList(page, 20));
            }
            else if(option == "SehirAdi")
            {
                return View(c.Sehirs.Where(x => x.SehirAdi == search || search == null).ToList().ToPagedList(page, 20));
            }
            else
            {
                return View(c.Sehirs.ToList().ToPagedList(page, 20));

            }



        }
    }
}