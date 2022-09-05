using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class Kullanıcı
    {
        [Key]
        public int KullanıcıID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "EPosta"), StringLength(52, MinimumLength = 7, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string EPosta { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Şifre"),StringLength(12, MinimumLength = 6, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string Sifre { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Rol"), Range(1, 20, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public int RolID { get; set; }











        public Rol Rol { get; set; }

    }
}
