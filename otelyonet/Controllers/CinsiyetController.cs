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
    public class CinsiyetController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public CinsiyetController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: Cinsiyets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cinsiyetler.ToListAsync());
        }

        // GET: Cinsiyets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinsiyet = await _context.Cinsiyetler
                .FirstOrDefaultAsync(m => m.CinsiyetID == id);
            if (cinsiyet == null)
            {
                return NotFound();
            }

            return View(cinsiyet);
        }

        // GET: Cinsiyets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cinsiyets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CinsiyetID,CinsiyetAdı")] Cinsiyet cinsiyet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinsiyet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinsiyet);
        }

        // GET: Cinsiyets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinsiyet = await _context.Cinsiyetler.FindAsync(id);
            if (cinsiyet == null)
            {
                return NotFound();
            }
            return View(cinsiyet);
        }

        // POST: Cinsiyets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CinsiyetID,CinsiyetAdı")] Cinsiyet cinsiyet)
        {
            if (id != cinsiyet.CinsiyetID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinsiyet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinsiyetExists(cinsiyet.CinsiyetID))
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
            return View(cinsiyet);
        }

        // GET: Cinsiyets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinsiyet = await _context.Cinsiyetler
                .FirstOrDefaultAsync(m => m.CinsiyetID == id);
            if (cinsiyet == null)
            {
                return NotFound();
            }

            return View(cinsiyet);
        }

        // POST: Cinsiyets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinsiyet = await _context.Cinsiyetler.FindAsync(id);
            _context.Cinsiyetler.Remove(cinsiyet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinsiyetExists(int id)
        {
            return _context.Cinsiyetler.Any(e => e.CinsiyetID == id);
        }
    }
}
