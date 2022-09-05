using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class Rezervasyon
    {
        [Key]
        public int RezervasyonID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Müşteri"), Range(1, 100000, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public int MüşteriID{ get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Oda"), Range(1, 1000, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public int OdaID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Ödeme Tipi"), Range(1, 20, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public int ÖdemeTipiID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Başlangıç Tarihi"), DataType(DataType.Date), Column(TypeName ="Date"),DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime BasTarih { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Bitiş Tarihi"), DataType(DataType.Date), Column(TypeName = "Date"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BitTarih { get; set; }

        public Müşteri Müşteri { get; set; }
        public Oda Oda { get; set; }
        public ÖdemeTipi ÖdemeTipi { get; set; }
    }
}
