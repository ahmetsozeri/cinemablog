using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinemaBiletOtomasyonu.Models.Siniflar
{
    public class Musteri
    {
        [Key]
        public int MusteriID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String KullaniciAdi { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String Sifre { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String MusteriAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String MusteriSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String Telefon { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String ePosta { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public String Adres { get; set; }

        public int Plaka { get; set; }
        public virtual Sehir Sehir { get; set; }
        public ICollection<Bilet> Bilets { get; set; }


    }
}