using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinemaBiletOtomasyonu.Models.Siniflar
{
    public class Koltuk
    {
        [Key]
        public int KoltukID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string KoltukAdi { get; set; }
        //public ICollection<SalonKoltuk> SalonKoltuks { get; set; }

        public int SalonID { get; set; }
        public virtual Salon Salon { get; set; }
        //public ICollection<FilmSalonSinema> FilmSalonSinemas { get; set; }


    }
}