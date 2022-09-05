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
    public class ÖdemeTipiController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public ÖdemeTipiController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: ÖdemeTipi
        public async Task<IActionResult> Index()
        {
            return View(await _context.ÖdemeTipleri.ToListAsync());
        }

        // GET: ÖdemeTipi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ödemeTipi = await _context.ÖdemeTipleri
                .FirstOrDefaultAsync(m => m.ÖdemeTipiID == id);
            if (ödemeTipi == null)
            {
                return NotFound();
            }

            return View(ödemeTipi);
        }

        // GET: ÖdemeTipi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ÖdemeTipi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ÖdemeTipiID,ÖdemeTipiAdı")] ÖdemeTipi ödemeTipi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ödemeTipi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ödemeTipi);
        }

        // GET: ÖdemeTipi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ödemeTipi = await _context.ÖdemeTipleri.FindAsync(id);
            if (ödemeTipi == null)
            {
                return NotFound();
            }
            return View(ödemeTipi);
        }

        // POST: ÖdemeTipi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ÖdemeTipiID,ÖdemeTipiAdı")] ÖdemeTipi ödemeTipi)
        {
            if (id != ödemeTipi.ÖdemeTipiID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ödemeTipi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ÖdemeTipiExists(ödemeTipi.ÖdemeTipiID))
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
            return View(ödemeTipi);
        }

        // GET: ÖdemeTipi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ödemeTipi = await _context.ÖdemeTipleri
                .FirstOrDefaultAsync(m => m.ÖdemeTipiID == id);
            if (ödemeTipi == null)
            {
                return NotFound();
            }

            return View(ödemeTipi);
        }

        // POST: ÖdemeTipi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ödemeTipi = await _context.ÖdemeTipleri.FindAsync(id);
            _context.ÖdemeTipleri.Remove(ödemeTipi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ÖdemeTipiExists(int id)
        {
            return _context.ÖdemeTipleri.Any(e => e.ÖdemeTipiID == id);
        }
    }
}
