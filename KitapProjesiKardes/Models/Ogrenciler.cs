using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KitapProjesiKardes.Models
{
    public class Ogrenciler
    {
        [Key]
        public int OgrenciID { get; set; }

        [Required]
        [Display(Name = "Öğrencinin Adı:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Adres:")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "E-Posta Adresi:")]
        public string Contact { get; set; }

        public virtual ICollection<Odunc> Odunc { get; set; }
    }
}