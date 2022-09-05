using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class OdaÖzellik
    {
        [Key]
        public int OdaÖzellikID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Oda"), Range(1, 1000, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public int OdaID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Manzara"), Range(1, 20, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public int ManzaraID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Oda Tipi"), Range(1, 20, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public int OdaTipiID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Duş Tipi"), Range(1, 20, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public int DuşTipiID { get; set; }

        [Display(Name = "Açıklama Adı"), StringLength(400, MinimumLength = 3, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string Açıklama { get; set; }



        public DuşTipi DuşTipi { get; set; }
        public OdaTipi OdaTipi { get; set; }
        public Manzara Manzara { get; set; }
        public Oda Oda { get; set; }
    }
}
