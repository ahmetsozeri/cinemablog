using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinemaBiletOtomasyonu.Models.Siniflar
{
    public class Sehir
    {
        [Key]
        public int Plaka { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string SehirAdi { get; set; }
        public ICollection<Sinema> Sinemas { get; set; }
        public ICollection<Musteri> Musteris { get; set; }
    }
}