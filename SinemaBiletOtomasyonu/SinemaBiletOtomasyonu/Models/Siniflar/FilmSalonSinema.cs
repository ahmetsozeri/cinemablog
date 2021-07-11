using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinemaBiletOtomasyonu.Models.Siniflar
{
    public class FilmSalonSinema
    {
        [Key]
        public int FSS_id { get; set; }

        public int SinemaID { get; set; }
        public virtual Sinema Sinema { get; set; }

        public int SalonID { get; set; }
        public virtual Salon Salon { get; set; }

        public int FilmID { get; set; }
        public virtual Film Film { get; set; }

        //public int KoltukID { get; set; }
        //public virtual Koltuk Koltuk { get; set; }

        public ICollection<Bilet> Bilets { get; set; }


    }
}