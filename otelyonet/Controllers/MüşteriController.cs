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
    public class MüşteriController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public MüşteriController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: Müşteri
        public async Task<IActionResult> Index()
        {
            var otelYonetDBContext = _context.Müşteriler.Include(m => m.Cinsiyet).Include(m => m.MüşteriTipi);
            return View(await otelYonetDBContext.ToListAsync());
        }

        // GET: Müşteri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var müşteri = await _context.Müşteriler
                .Include(m => m.Cinsiyet)
                .Include(m => m.MüşteriTipi)
                .FirstOrDefaultAsync(m => m.MüşteriID == id);
            if (müşteri == null)
            {
                return NotFound();
            }

            return View(müşteri);
        }

        // GET: Müşteri/Create
        public IActionResult Create()
        {
            ViewData["CinsiyetID"] = new SelectList(_context.Cinsiyetler, "CinsiyetID", "CinsiyetAdı");
            ViewData["MüşteriTipiID"] = new SelectList(_context.MüşteriTipleri, "MüşteriTipiID", "MüşteriTipiAdı");
            return View();
        }

        // POST: Müşteri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusteriID,MusteriTamAdı,MusteriSoyadi,MobilNO,CinsiyetID,MüşteriTipiID")] Müşteri müşteri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(müşteri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CinsiyetID"] = new SelectList(_context.Cinsiyetler, "CinsiyetID", "CinsiyetAdı", müşteri.CinsiyetID);
            ViewData["MüşteriTipiID"] = new SelectList(_context.MüşteriTipleri, "MüşteriTipiID", "MüşteriTipiAdı", müşteri.MüşteriTipiID);
            return View(müşteri);
        }

        // GET: Müşteri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var müşteri = await _context.Müşteriler.FindAsync(id);
            if (müşteri == null)
            {
                return NotFound();
            }
            ViewData["CinsiyetID"] = new SelectList(_context.Cinsiyetler, "CinsiyetID", "CinsiyetAdı", müşteri.CinsiyetID);
            ViewData["MüşteriTipiID"] = new SelectList(_context.MüşteriTipleri, "MüşteriTipiID", "MüşteriTipiAdı", müşteri.MüşteriTipiID);
            return View(müşteri);
        }

        // POST: Müşteri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusteriID,MusteriTamAdı,MusteriSoyadi,MobilNO,CinsiyetID,MüşteriTipiID")] Müşteri müşteri)
        {
            if (id != müşteri.MüşteriID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(müşteri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MüşteriExists(müşteri.MüşteriID))
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
            ViewData["CinsiyetID"] = new SelectList(_context.Cinsiyetler, "CinsiyetID", "CinsiyetAdı", müşteri.CinsiyetID);
            ViewData["MüşteriTipiID"] = new SelectList(_context.MüşteriTipleri, "MüşteriTipiID", "MüşteriTipiAdı", müşteri.MüşteriTipiID);
            return View(müşteri);
        }

        // GET: Müşteri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var müşteri = await _context.Müşteriler
                .Include(m => m.Cinsiyet)
                .Include(m => m.MüşteriTipi)
                .FirstOrDefaultAsync(m => m.MüşteriID == id);
            if (müşteri == null)
            {
                return NotFound();
            }

            return View(müşteri);
        }

        // POST: Müşteri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var müşteri = await _context.Müşteriler.FindAsync(id);
            _context.Müşteriler.Remove(müşteri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MüşteriExists(int id)
        {
            return _context.Müşteriler.Any(e => e.MüşteriID == id);
        }
    }
}
