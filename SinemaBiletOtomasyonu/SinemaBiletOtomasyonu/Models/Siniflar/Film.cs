using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinemaBiletOtomasyonu.Models.Siniflar
{
    public class Film
    {
        [Key]
        public int FilmID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string FilmAdi { get; set; }
        public int FilmSuresi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Afis { get; set; }
        public double Fiyat { get; set; }

        public int TurID { get; set; }

        [Column(TypeName = "Varchar")]
        [MaxLength]
        public string KisaAciklama { get; set; }

        [Column(TypeName = "text")]
        [MaxLength]
        [AllowHtml]
        public string Aciklama { get; set; }
      
        public virtual FilmTur FilmTur { get; set; }
        //public ICollection<Bilet> Bilets { get; set; }
        //public ICollection<FilmSinema> FilmSinemas { get; set; }

       
        public ICollection<FilmSalonSinema> FilmSalonSinemas { get; set; }



    }
}