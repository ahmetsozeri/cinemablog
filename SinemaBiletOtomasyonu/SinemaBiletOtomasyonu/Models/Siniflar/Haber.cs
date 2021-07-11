using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SinemaBiletOtomasyonu.Models.Siniflar
{
    public class Haber
    {
        public long id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Title { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Metatitle { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string KucukResim { get; set; }

        [Column(TypeName = "Varchar")]
        [MaxLength]
        public string Shortinfo { get; set; }
        [Column(TypeName = "text")]
        [MaxLength]
        [AllowHtml]
        public string İcerik { get; set; }
        public DateTime? PostedDate { get; set; }
        public bool Active { get; set; }

    }
}