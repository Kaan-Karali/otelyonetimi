using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class Müşteri
    {
        [Key]
        public int MüşteriID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"),Display(Name = "Adı ve varsa İkinci Adı"),StringLength(40, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string MüşteriTamAdı { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"),Display(Name = "Soyadı"),StringLength(20, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string MüşteriSoyadi { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"),Display(Name = "Mobil No"),StringLength(10, MinimumLength = 10, ErrorMessage = "{0} {1} karakter olmalı.")]
        public string  MobilNO{ get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Cinsiyet"), Range(1, 2, ErrorMessage = "{0} seçilmeli.")]
        public int CinsiyetID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Müşteri Tipi"), Range(1, 20, ErrorMessage = "{0} seçilmeli.")]
        public int MüşteriTipiID { get; set; }

        public Cinsiyet Cinsiyet { get; set; }

        public MüşteriTipi MüşteriTipi { get; set; }
    }
}
