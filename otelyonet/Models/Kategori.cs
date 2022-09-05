using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Kategori Adı"), StringLength(30, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")]
        public string KategoriAdı { get; set; }

        public int? BabaKategoriID { get; set; }

        [ForeignKey("BabaKategoriID")]
        public Kategori BabaKategori { get; set; }


    }
}
