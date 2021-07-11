using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinemaBiletOtomasyonu.Models.Siniflar
{
    public class Sinema
    {
        [Key]
        public int SinemaID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string SinemaAdi { get; set; }

        public int? Plaka { get; set; }
        public bool IsChecked { get; set; }

        public virtual Sehir Sehir { get; set; }


        //public ICollection<SinemaSalon> SinemaSalons { get; set; }


        //public ICollection<FilmSinema> FilmSinemas { get; set; }

        public ICollection<Salon> Salons { get; set; }

        public ICollection<FilmSalonSinema> FilmSalonSinemas { get; set; }



    }
}