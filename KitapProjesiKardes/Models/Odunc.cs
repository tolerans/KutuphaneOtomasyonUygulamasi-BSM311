using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitapProjesiKardes.Models
{
    public class Odunc
    {
        [Key]
        public int OduncId { get; set; }

        [Required]
        [Display(Name = "Ödünç Alınma Tarihi:")]
        public DateTime OduncAlinmaTarihi { get; set; }

        [Required]
        [Display(Name = "Teslim Edileceği Tarih:")]
        public DateTime? TeslimEdilmeTarihi { get; set; }

        [ForeignKey("Ogrenciler")]
        [Display(Name = "Öğrenci Listesi:")]
        public int OgrenciID { get; set; }

        [ForeignKey("Kitaplar")]
        [Display(Name = "Kitap Listesi:")]
        public int KitapID { get; set; }

        public virtual Ogrenciler Ogrenciler { get; set; }

        public virtual Kitaplar Kitaplar { get; set; }
    }
}