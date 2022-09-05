using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class Birim
    {
        [Key]
        public int BirimID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Birim Adı")
            , StringLength(20, MinimumLength = 3, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string BirimAdı { get; set; }
    }
}
