using Microsoft.AspNetCore.Mvc;
using otelyonet.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Controllers
{
    public class ÖrnekKodController : Controller
    {
        public IActionResult LogAlma()
        {
            LogAlmaViewModel vm = new LogAlmaViewModel();


            string birinciYazı = "ali";
            string ikinciYazı = "5";

            try
            {
                int x = Convert.ToInt32(birinciYazı);
                int y = Convert.ToInt32(ikinciYazı);

                vm.Sonuç= x + y;

            }
            catch (Exception e)
            {
                vm.Hata = e.Message;

                string filePath = @"C:\Users\iskender.cihan\Documents\Hata.txt";

                Exception ex = e;

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Tarih : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Hata : " + ex.Message+"<br />"+
                             "Hata şu girdiler ile oluştu "+birinciYazı+"--"+ikinciYazı);
                        writer.WriteLine("Hata Kaynağı : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }

                //throw;
            }
            

            return View(vm);
        }
    }
}
