using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using otelyonet.Data;
using otelyonet.Models;
using otelyonet.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Controllers
{
    public class AnasayfaController : Controller
    {

        private readonly OtelYonetDBContext _context;

        public AnasayfaController(OtelYonetDBContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {

            anasayfaViewModel vm = new anasayfaViewModel(); // Boş bir anasayfaviewmodel nesnesi oluşturuldu .
            vm.HizmetListesi = _context.Hizmetler.ToList();



            vm.OdaTipListesi = _context.OdaTipleri.Include(a=>a.OdaÖzellikleri).ThenInclude(a=>a.Oda);

            vm.TesisListesi = _context.Tesisler.ToList();



            return View(vm);
        }

        public IActionResult Hata()
        {

            return View();
        }
    }
}
