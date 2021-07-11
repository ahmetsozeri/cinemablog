using SinemaBiletOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinemaBiletOtomasyonu.Controllers
{
    public class BiletController : Controller
    {
        Context c = new Context();
        // GET: Bilet
        public ActionResult Index()
        {
            var degerler = c.Koltuks.ToList();
            return View(degerler);
        }
    }
}