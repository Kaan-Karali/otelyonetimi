using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace otelyonet.Models
{
    public class OdaTipi
    {
        [Key]
        public int OdaTipiID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Oda Tipi Adı"), StringLength(20, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string OdaTipiAdı { get; set; }

        public ICollection<OdaÖzellik> OdaÖzellikleri { get; set; }

    }
}