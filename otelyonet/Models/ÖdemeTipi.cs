using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class ÖdemeTipi
    {
        [Key]
        public int ÖdemeTipiID { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Ödeme Tipi Adı"), StringLength(30, MinimumLength = 1, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string ÖdemeTipiAdı { get; set; }
    }
}
