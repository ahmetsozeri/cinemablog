using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinemaBiletOtomasyonu.Models.Siniflar
{
    public class Seans
    {
        [Key]
        public int SeansID { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime Saat { get; set; }
        public ICollection<Bilet> Bilets { get; set; }
    }
}