using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinemaBiletOtomasyonu.Models.Siniflar
{
    public class Bilet
    {
        [Key]
        public int BiletID { get; set; }

        public int MusteriID { get; set; }
        public virtual Musteri Musteri { get; set; }

        public int FSS_id { get; set; }
        public virtual FilmSalonSinema FilmSalonSinema { get; set; }
    }
}