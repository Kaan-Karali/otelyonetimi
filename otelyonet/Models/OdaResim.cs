using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class OdaResim
    {
        [Key]
        public int OdaResimID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Oda"), Range(-5, 100, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public int OdaID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "ResimYolu"), StringLength(200, MinimumLength = 1, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string ResimYolu { get; set; }

        [NotMapped]
        public IFormFile ResimDosyası { get; set; }

        public Oda Oda { get; set; }

        



    }
}
