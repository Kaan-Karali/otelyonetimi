using System.ComponentModel.DataAnnotations;

namespace otelyonet.Models
{
    public class Manzara
    {
        [Key]
        public int ManzaraID { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Manzara Adı"), StringLength(20, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string ManzaraAdı { get; set; }
    }
}