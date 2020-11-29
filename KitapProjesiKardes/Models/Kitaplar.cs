using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KitapProjesiKardes.Models
{
    public class Kitaplar
    {
        [Key]
        public int KitapID { get; set; }

        [Required]
        [Display(Name = "ISBN Numarası:")]
        public int ISBN { get; set; }

        [Required]
        [Display(Name = "Demirbaş Numarası:")]
        public int DemirBasNO { get; set; }

        [Required]
        [Display(Name = "Kitap Adı:")]
        public string KitapAdi { get; set; }
        [Display(Name = "Kitap Dili:")]
        public string Dil { get; set; }
        [Display(Name = "Kitabın Konusu:")]
        public string Konu { get; set; }
        [Display(Name = "Yer Numarası:")]
        public string YerNO { get; set; }

        public virtual ICollection<Odunc> Odunc { get; set; }
    }
}