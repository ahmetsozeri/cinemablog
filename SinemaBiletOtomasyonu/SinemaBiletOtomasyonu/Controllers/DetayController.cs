using SinemaBiletOtomasyonu.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinemaBiletOtomasyonu.Controllers
{
    public class DetayController : Controller
    {
        Context c = new Context();
        // GET: Detay
        public ActionResult Index(int id)
        {
            Class1 cs = new Class1();
            cs.Deger1 = c.Habers.Where(x => x.id == id).ToList();
            cs.Deger2 = c.Detays.Where(y => y.DetayID == id).ToList();
            return View(cs);
        }
    }
}