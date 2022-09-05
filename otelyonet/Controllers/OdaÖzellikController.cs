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
    public class OdaÖzellikController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public OdaÖzellikController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: OdaÖzellik
        public async Task<IActionResult> Index()
        {
            var otelYonetDBContext = _context.OdaÖzellikleri.Include(o => o.DuşTipi).Include(o => o.Manzara).Include(o => o.Oda).Include(o => o.OdaTipi);
            return View(await otelYonetDBContext.ToListAsync());
        }

        // GET: OdaÖzellik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odaÖzellik = await _context.OdaÖzellikleri
                .Include(o => o.DuşTipi)
                .Include(o => o.Manzara)
                .Include(o => o.Oda)
                .Include(o => o.OdaTipi)
                .FirstOrDefaultAsync(m => m.OdaÖzellikID == id);
            if (odaÖzellik == null)
            {
                return NotFound();
            }

            return View(odaÖzellik);
        }

        // GET: OdaÖzellik/Create
        public IActionResult Create()
        {
            ViewData["DuşTipiID"] = new SelectList(_context.DuşTipleri, "DuşTipiID", "DuşTipiAdı");
            ViewData["ManzaraID"] = new SelectList(_context.Manzaralar, "ManzaraID", "ManzaraAdı");
            ViewData["OdaID"] = new SelectList(_context.Odalar, "OdaID", "OdaAdı");
            ViewData["OdaTipiID"] = new SelectList(_context.OdaTipleri, "OdaTipiID", "OdaTipiAdı");
            return View();
        }

        // POST: OdaÖzellik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OdaÖzellikID,OdaID,ManzaraID,OdaTipiID,DuşTipiID,Açıklama")] OdaÖzellik odaÖzellik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odaÖzellik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DuşTipiID"] = new SelectList(_context.DuşTipleri, "DuşTipiID", "DuşTipiAdı", odaÖzellik.DuşTipiID);
            ViewData["ManzaraID"] = new SelectList(_context.Manzaralar, "ManzaraID", "ManzaraAdı", odaÖzellik.ManzaraID);
            ViewData["OdaID"] = new SelectList(_context.Odalar, "OdaID", "OdaAdı", odaÖzellik.OdaID);
            ViewData["OdaTipiID"] = new SelectList(_context.OdaTipleri, "OdaTipiID", "OdaTipiAdı", odaÖzellik.OdaTipiID);
            return View(odaÖzellik);
        }

        // GET: OdaÖzellik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odaÖzellik = await _context.OdaÖzellikleri.FindAsync(id);
            if (odaÖzellik == null)
            {
                return NotFound();
            }
            ViewData["DuşTipiID"] = new SelectList(_context.DuşTipleri, "DuşTipiID", "DuşTipiAdı", odaÖzellik.DuşTipiID);
            ViewData["ManzaraID"] = new SelectList(_context.Manzaralar, "ManzaraID", "ManzaraAdı", odaÖzellik.ManzaraID);
            ViewData["OdaID"] = new SelectList(_context.Odalar, "OdaID", "OdaAdı", odaÖzellik.OdaID);
            ViewData["OdaTipiID"] = new SelectList(_context.OdaTipleri, "OdaTipiID", "OdaTipiAdı", odaÖzellik.OdaTipiID);
            return View(odaÖzellik);
        }

        // POST: OdaÖzellik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OdaÖzellikID,OdaID,ManzaraID,OdaTipiID,DuşTipiID,Açıklama")] OdaÖzellik odaÖzellik)
        {
            if (id != odaÖzellik.OdaÖzellikID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odaÖzellik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdaÖzellikExists(odaÖzellik.OdaÖzellikID))
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
            ViewData["DuşTipiID"] = new SelectList(_context.DuşTipleri, "DuşTipiID", "DuşTipiAdı", odaÖzellik.DuşTipiID);
            ViewData["ManzaraID"] = new SelectList(_context.Manzaralar, "ManzaraID", "ManzaraAdı", odaÖzellik.ManzaraID);
            ViewData["OdaID"] = new SelectList(_context.Odalar, "OdaID", "OdaAdı", odaÖzellik.OdaID);
            ViewData["OdaTipiID"] = new SelectList(_context.OdaTipleri, "OdaTipiID", "OdaTipiAdı", odaÖzellik.OdaTipiID);
            return View(odaÖzellik);
        }

        // GET: OdaÖzellik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odaÖzellik = await _context.OdaÖzellikleri
                .Include(o => o.DuşTipi)
                .Include(o => o.Manzara)
                .Include(o => o.Oda)
                .Include(o => o.OdaTipi)
                .FirstOrDefaultAsync(m => m.OdaÖzellikID == id);
            if (odaÖzellik == null)
            {
                return NotFound();
            }

            return View(odaÖzellik);
        }

        // POST: OdaÖzellik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odaÖzellik = await _context.OdaÖzellikleri.FindAsync(id);
            _context.OdaÖzellikleri.Remove(odaÖzellik);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdaÖzellikExists(int id)
        {
            return _context.OdaÖzellikleri.Any(e => e.OdaÖzellikID == id);
        }
    }
}
