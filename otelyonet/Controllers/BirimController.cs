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
    public class BirimController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public BirimController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: Birims
        public async Task<IActionResult> Index()
        {
            return View(await _context.Birimler.ToListAsync());
        }

        // GET: Birims/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birim = await _context.Birimler
                .FirstOrDefaultAsync(m => m.BirimID == id);
            if (birim == null)
            {
                return NotFound();
            }

            return View(birim);
        }

        // GET: Birims/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Birims/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BirimID,BirimAdı")] Birim birim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(birim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(birim);
        }

        // GET: Birims/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birim = await _context.Birimler.FindAsync(id);
            if (birim == null)
            {
                return NotFound();
            }
            return View(birim);
        }

        // POST: Birims/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BirimID,BirimAdı")] Birim birim)
        {
            if (id != birim.BirimID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(birim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BirimExists(birim.BirimID))
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
            return View(birim);
        }

        // GET: Birims/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birim = await _context.Birimler
                .FirstOrDefaultAsync(m => m.BirimID == id);
            if (birim == null)
            {
                return NotFound();
            }

            return View(birim);
        }

        // POST: Birims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var birim = await _context.Birimler.FindAsync(id);
            _context.Birimler.Remove(birim);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BirimExists(int id)
        {
            return _context.Birimler.Any(e => e.BirimID == id);
        }
    }
}
