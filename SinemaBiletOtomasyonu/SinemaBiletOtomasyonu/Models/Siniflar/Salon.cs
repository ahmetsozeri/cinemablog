using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinemaBiletOtomasyonu.Models.Siniflar
{
    public class Salon
    {
        [Key]
        public int SalonID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string SalonAdi { get; set; }
        //public ICollection<SalonKoltuk> SalonKoltuks { get; set; }
        //public ICollection<SinemaSalon> SinemaSalons { get; set; }
        public int SinemaID { get; set; }
        public virtual Sinema Sinema { get; set; }

        public ICollection<Koltuk> Koltuks { get; set; }

        public ICollection<FilmSalonSinema> FilmSalonSinemas { get; set; }


    }
}