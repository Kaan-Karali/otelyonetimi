using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using otelyonet.Data;
using otelyonet.Models;

namespace otelyonet.Controllers
{
    public class RezervasyonController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public RezervasyonController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: Rezervasyon
        public async Task<IActionResult> Index()
        {
            var otelYonetDBContext = _context.Rezervasyonlar.Include(r => r.Müşteri).Include(r => r.Oda).Include(r => r.ÖdemeTipi);


            
            return View(await otelYonetDBContext.ToListAsync());
        }

        // GET: Rezervasyon/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervasyon = await _context.Rezervasyonlar
                .Include(r => r.Müşteri)
                .Include(r => r.Oda)
                .Include(r => r.ÖdemeTipi)
                .FirstOrDefaultAsync(m => m.RezervasyonID == id);
            if (rezervasyon == null)
            {
                return NotFound();
            }

            return View(rezervasyon);
        }

        // GET: Rezervasyon/Create
        public IActionResult Create()
        {
            ViewData["MüşteriID"] = new SelectList(_context.Müşteriler, "MüşteriID", "MüşteriTamAdı");
            ViewData["OdaID"] = new SelectList(_context.Odalar, "OdaID", "OdaAdı");
            ViewData["ÖdemeTipiID"] = new SelectList(_context.ÖdemeTipleri, "ÖdemeTipiID", "ÖdemeTipiAdı");
            return View();
        }

        // POST: Rezervasyon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RezervasyonID,MüşteriID,OdaID,ÖdemeTipiID,BasTarih,BitTarih")] Rezervasyon rezervasyon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervasyon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MüşteriID"] = new SelectList(_context.Müşteriler, "MüşteriID", "MüşteriTamAdı", rezervasyon.MüşteriID);
            ViewData["OdaID"] = new SelectList(_context.Odalar, "OdaID", "OdaAdı", rezervasyon.OdaID);
            ViewData["ÖdemeTipiID"] = new SelectList(_context.ÖdemeTipleri, "ÖdemeTipiID", "ÖdemeTipiAdı", rezervasyon.ÖdemeTipiID);
            return View(rezervasyon);
        }

        // GET: Rezervasyon/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervasyon = await _context.Rezervasyonlar.FindAsync(id);
            if (rezervasyon == null)
            {
                return NotFound();
            }
            ViewData["MüşteriID"] = new SelectList(_context.Müşteriler, "MüşteriID", "MüşteriTamAdı", rezervasyon.MüşteriID);
            ViewData["OdaID"] = new SelectList(_context.Odalar, "OdaID", "OdaAdı", rezervasyon.OdaID);
            ViewData["ÖdemeTipiID"] = new SelectList(_context.ÖdemeTipleri, "ÖdemeTipiID", "ÖdemeTipiAdı", rezervasyon.ÖdemeTipiID);
            return View(rezervasyon);
        }

        // POST: Rezervasyon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RezervasyonID,MüşteriID,OdaID,ÖdemeTipiID,BasTarih,BitTarih")] Rezervasyon rezervasyon)
        {
            if (id != rezervasyon.RezervasyonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervasyon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervasyonExists(rezervasyon.RezervasyonID))
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
            ViewData["MüşteriID"] = new SelectList(_context.Müşteriler, "MüşteriID", "MüşteriTamAdı", rezervasyon.MüşteriID);
            ViewData["OdaID"] = new SelectList(_context.Odalar, "OdaID", "OdaAdı", rezervasyon.OdaID);
            ViewData["ÖdemeTipiID"] = new SelectList(_context.ÖdemeTipleri, "ÖdemeTipiID", "ÖdemeTipiAdı", rezervasyon.ÖdemeTipiID);
            return View(rezervasyon);
        }

        // GET: Rezervasyon/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervasyon = await _context.Rezervasyonlar
                .Include(r => r.Müşteri)
                .Include(r => r.Oda)
                .Include(r => r.ÖdemeTipi)
                .FirstOrDefaultAsync(m => m.RezervasyonID == id);
            if (rezervasyon == null)
            {
                return NotFound();
            }

            return View(rezervasyon);
        }

        // POST: Rezervasyon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervasyon = await _context.Rezervasyonlar.FindAsync(id);
            _context.Rezervasyonlar.Remove(rezervasyon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervasyonExists(int id)
        {
            return _context.Rezervasyonlar.Any(e => e.RezervasyonID == id);
        }
    }
}
