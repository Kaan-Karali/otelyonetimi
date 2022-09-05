using System.ComponentModel.DataAnnotations;

namespace otelyonet.Models
{
    public class DuşTipi
    {
        [Key]
        public int DuşTipiID { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Duş Tipi Adı"), StringLength(12, MinimumLength = 3, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string DuşTipiAdı { get; set; }
    }
}