using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinemaBiletOtomasyonu.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string HaberAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string Haberİcerik { get; set; }
    }
}