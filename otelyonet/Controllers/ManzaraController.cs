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
    public class ManzaraController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public ManzaraController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: Manzara
        public async Task<IActionResult> Index()
        {
            return View(await _context.Manzaralar.ToListAsync());
        }

        // GET: Manzara/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manzara = await _context.Manzaralar
                .FirstOrDefaultAsync(m => m.ManzaraID == id);
            if (manzara == null)
            {
                return NotFound();
            }

            return View(manzara);
        }

        // GET: Manzara/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manzara/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManzaraID,ManzaraAdı")] Manzara manzara)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manzara);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manzara);
        }

        // GET: Manzara/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manzara = await _context.Manzaralar.FindAsync(id);
            if (manzara == null)
            {
                return NotFound();
            }
            return View(manzara);
        }

        // POST: Manzara/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManzaraID,ManzaraAdı")] Manzara manzara)
        {
            if (id != manzara.ManzaraID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manzara);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManzaraExists(manzara.ManzaraID))
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
            return View(manzara);
        }

        // GET: Manzara/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manzara = await _context.Manzaralar
                .FirstOrDefaultAsync(m => m.ManzaraID == id);
            if (manzara == null)
            {
                return NotFound();
            }

            return View(manzara);
        }

        // POST: Manzara/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manzara = await _context.Manzaralar.FindAsync(id);
            _context.Manzaralar.Remove(manzara);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManzaraExists(int id)
        {
            return _context.Manzaralar.Any(e => e.ManzaraID == id);
        }
    }
}
