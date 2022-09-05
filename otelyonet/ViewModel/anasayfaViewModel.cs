using otelyonet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.ViewModel
{
    public class anasayfaViewModel
    {

        public IEnumerable<Hizmet> HizmetListesi{ get; set; }
        public IEnumerable<OdaTipi> OdaTipListesi{ get; set; }
        public IEnumerable<Tesis> TesisListesi { get; set; }

    }
}
