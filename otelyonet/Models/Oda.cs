using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class Oda
    {
        [Key]
        public int OdaID { get; set; }

        [Required(ErrorMessage ="{0} Gerekli"),Display(Name ="Oda Adı"),StringLength(30,MinimumLength =1,ErrorMessage ="{0} {2} ve {1} arasında olmalı.")]
        public string OdaAdı { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Kat Numarası"), Range(-5,100,ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public int KatNO { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Yatak Sayısı"), Range(1, 10, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public int YatakSayısı{ get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Oda Fiyatı"), Range(0.00, 999999.99, ErrorMessage = "{0} {1} ve {2} arasında olmalı."), Column(TypeName = "decimal(8, 2)")]
        public decimal OdaFiyatı { get; set; }

        //2.KATTAKİ ODALARIN YATAK SAYILARI
        //


    }
}
