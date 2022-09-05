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
    public class TesisController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public TesisController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: Tesis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tesisler.ToListAsync());
        }

        // GET: Tesis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tesis = await _context.Tesisler
                .FirstOrDefaultAsync(m => m.TesisID == id);
            if (tesis == null)
            {
                return NotFound();
            }

            return View(tesis);
        }

        // GET: Tesis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tesis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TesisID,TesisAdı,Açıklama")] Tesis tesis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tesis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tesis);
        }

        // GET: Tesis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tesis = await _context.Tesisler.FindAsync(id);
            if (tesis == null)
            {
                return NotFound();
            }
            return View(tesis);
        }

        // POST: Tesis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TesisID,TesisAdı,Açıklama")] Tesis tesis)
        {
            if (id != tesis.TesisID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tesis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TesisExists(tesis.TesisID))
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
            return View(tesis);
        }

        // GET: Tesis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tesis = await _context.Tesisler
                .FirstOrDefaultAsync(m => m.TesisID == id);
            if (tesis == null)
            {
                return NotFound();
            }

            return View(tesis);
        }

        // POST: Tesis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tesis = await _context.Tesisler.FindAsync(id);
            _context.Tesisler.Remove(tesis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TesisExists(int id)
        {
            return _context.Tesisler.Any(e => e.TesisID == id);
        }
    }
}
