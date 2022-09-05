using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }

        [
            Required(ErrorMessage = "{0} Gerekli"), 
            Display(Name = "Rol Adı"), 
            StringLength(20, MinimumLength = 3, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")
            ]
        public string RolAdı { get; set; }
    }
}
