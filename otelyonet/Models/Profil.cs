using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class Profil
    {
        [Key]
        public int ProfilID { get; set; }

        public int KullanıcıID { get; set; }

        public string Adres{ get; set; }
        public string CepNO{ get; set; }
        public string EvNO{ get; set; }
        public string İşNO{ get; set; }
        public string Meslek{ get; set; }

        
        public string ResimYolu{ get; set; }

        [NotMapped]
        public IFormFile ResimDosyası{ get; set; }


        public Kullanıcı Kullanıcı { get; set; }



    }
}
