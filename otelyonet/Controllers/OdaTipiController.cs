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
    public class OdaTipiController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public OdaTipiController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: OdaTipi
        public async Task<IActionResult> Index()
        {
            return View(await _context.OdaTipleri.ToListAsync());
        }

        // GET: OdaTipi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odaTipi = await _context.OdaTipleri
                .FirstOrDefaultAsync(m => m.OdaTipiID == id);
            if (odaTipi == null)
            {
                return NotFound();
            }

            return View(odaTipi);
        }

        // GET: OdaTipi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OdaTipi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OdaTipiID,OdaTipiAdı")] OdaTipi odaTipi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odaTipi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(odaTipi);
        }

        // GET: OdaTipi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odaTipi = await _context.OdaTipleri.FindAsync(id);
            if (odaTipi == null)
            {
                return NotFound();
            }
            return View(odaTipi);
        }

        // POST: OdaTipi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OdaTipiID,OdaTipiAdı")] OdaTipi odaTipi)
        {
            if (id != odaTipi.OdaTipiID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odaTipi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdaTipiExists(odaTipi.OdaTipiID))
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
            return View(odaTipi);
        }

        // GET: OdaTipi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odaTipi = await _context.OdaTipleri
                .FirstOrDefaultAsync(m => m.OdaTipiID == id);
            if (odaTipi == null)
            {
                return NotFound();
            }

            return View(odaTipi);
        }

        // POST: OdaTipi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odaTipi = await _context.OdaTipleri.FindAsync(id);
            _context.OdaTipleri.Remove(odaTipi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdaTipiExists(int id)
        {
            return _context.OdaTipleri.Any(e => e.OdaTipiID == id);
        }
    }
}
