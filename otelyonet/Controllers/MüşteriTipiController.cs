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
    public class MüşteriTipiController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public MüşteriTipiController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: MüşteriTipi
        public async Task<IActionResult> Index()
        {
            return View(await _context.MüşteriTipleri.ToListAsync());
        }

        // GET: MüşteriTipi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var müşteriTipi = await _context.MüşteriTipleri
                .FirstOrDefaultAsync(m => m.MüşteriTipiID == id);
            if (müşteriTipi == null)
            {
                return NotFound();
            }

            return View(müşteriTipi);
        }

        // GET: MüşteriTipi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MüşteriTipi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MüşteriTipiID,MüşteriTipiAdı")] MüşteriTipi müşteriTipi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(müşteriTipi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(müşteriTipi);
        }

        // GET: MüşteriTipi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var müşteriTipi = await _context.MüşteriTipleri.FindAsync(id);
            if (müşteriTipi == null)
            {
                return NotFound();
            }
            return View(müşteriTipi);
        }

        // POST: MüşteriTipi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MüşteriTipiID,MüşteriTipiAdı")] MüşteriTipi müşteriTipi)
        {
            if (id != müşteriTipi.MüşteriTipiID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(müşteriTipi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MüşteriTipiExists(müşteriTipi.MüşteriTipiID))
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
            return View(müşteriTipi);
        }

        // GET: MüşteriTipi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var müşteriTipi = await _context.MüşteriTipleri
                .FirstOrDefaultAsync(m => m.MüşteriTipiID == id);
            if (müşteriTipi == null)
            {
                return NotFound();
            }

            return View(müşteriTipi);
        }

        // POST: MüşteriTipi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var müşteriTipi = await _context.MüşteriTipleri.FindAsync(id);
            _context.MüşteriTipleri.Remove(müşteriTipi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MüşteriTipiExists(int id)
        {
            return _context.MüşteriTipleri.Any(e => e.MüşteriTipiID == id);
        }
    }
}
