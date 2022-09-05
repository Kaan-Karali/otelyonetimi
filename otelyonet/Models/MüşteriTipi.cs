using System.ComponentModel.DataAnnotations;

namespace otelyonet.Models
{
    public class MüşteriTipi
    {
        [Key] 
        public int MüşteriTipiID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"),Display(Name = "Müşteri Tipi Adı"),StringLength(20, MinimumLength = 3, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string MüşteriTipiAdı { get; set; }
    }
}