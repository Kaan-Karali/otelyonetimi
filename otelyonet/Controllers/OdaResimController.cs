using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using otelyonet.Data;
using otelyonet.Models;

namespace otelyonet.Controllers
{
    public class OdaResimController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public OdaResimController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: OdaResim
        public async Task<IActionResult> Index()
        {
            var otelYonetDBContext = _context.OdaResimleri.Include(o => o.Oda);
            return View(await otelYonetDBContext.ToListAsync());
        }

        // GET: OdaResim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odaResim = await _context.OdaResimleri
                .Include(o => o.Oda)
                .FirstOrDefaultAsync(m => m.OdaResimID == id);
            if (odaResim == null)
            {
                return NotFound();
            }

            return View(odaResim);
        }

        // GET: OdaResim/Create
        public IActionResult Create()
        {
            ViewData["OdaID"] = new SelectList(_context.Odalar, "OdaID", "OdaAdı");
            return View();
        }

        // POST: OdaResim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OdaResimID,OdaID,ResimDosyası")] OdaResim odaResim)
        {
            if (odaResim.ResimDosyası != null && odaResim.ResimDosyası.Length > 0)
            {
                string fileTime = DateTime.UtcNow.ToString("yyMMddHHmmss");
                string fileName = fileTime + Path.GetFileName(odaResim.ResimDosyası.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", fileName);

                odaResim.ResimYolu= filePath;
                _context.Add(odaResim);
                _context.SaveChanges();

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await odaResim.ResimDosyası.CopyToAsync(fileStream);
                }
                return RedirectToAction(nameof(Index));

            }
            return View(odaResim);




            //odaResim.ResimYolu = "uploads/"+odaResim.ResimDosyası.FileName;
            //ModelState.Remove("ResimYolu");
            //if (ModelState.IsValid)
            //{
            //    _context.Add(odaResim);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["OdaID"] = new SelectList(_context.Odalar, "OdaID", "OdaAdı", odaResim.OdaID);
            //return View(odaResim);
        }

        // GET: OdaResim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odaResim = await _context.OdaResimleri.FindAsync(id);
            if (odaResim == null)
            {
                return NotFound();
            }
            ViewData["OdaID"] = new SelectList(_context.Odalar, "OdaID", "OdaAdı", odaResim.OdaID);
            return View(odaResim);
        }

        // POST: OdaResim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OdaResimID,OdaID,ResimYolu")] OdaResim odaResim)
        {
            if (id != odaResim.OdaResimID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odaResim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdaResimExists(odaResim.OdaResimID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OdaID"] = new SelectList(_context.Odalar, "OdaID", "OdaAdı", odaResim.OdaID);
            return View(odaResim);
        }

        // GET: OdaResim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odaResim = await _context.OdaResimleri
                .Include(o => o.Oda)
                .FirstOrDefaultAsync(m => m.OdaResimID == id);
            if (odaResim == null)
            {
                return NotFound();
            }

            return View(odaResim);
        }

        // POST: OdaResim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odaResim = await _context.OdaResimleri.FindAsync(id);
            _context.OdaResimleri.Remove(odaResim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdaResimExists(int id)
        {
            return _context.OdaResimleri.Any(e => e.OdaResimID == id);
        }
    }
}
