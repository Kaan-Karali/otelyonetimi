using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class Hizmet
    {
        [Key]

        public int HizmetID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Hizmet Adı"), StringLength(30, MinimumLength = 3, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string HizmetAdı { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Hizmet Açıklaması"), StringLength(400, MinimumLength = 3, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string Açıklama{ get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Hizmet Resmi"), StringLength(100, MinimumLength = 3, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string ResimYolu { get; set; }

        [NotMapped]
        public IFormFile ResimDosyası{ get; set; }




    }
}
