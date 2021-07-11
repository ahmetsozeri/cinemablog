using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinemaBiletOtomasyonu.Models.Siniflar
{
    public class FilmTur
    {
        [Key]
        public int TurID { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TurAdi { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}