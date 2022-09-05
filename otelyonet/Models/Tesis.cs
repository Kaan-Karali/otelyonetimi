using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class Tesis
    {
        [Key]
        public int TesisID { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Tesis Adı"), StringLength(30, MinimumLength = 1, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string TesisAdı { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Açıklama"), StringLength(400, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string Açıklama { get; set; }
    }
}
