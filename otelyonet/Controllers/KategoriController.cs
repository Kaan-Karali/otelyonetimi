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
    public class KategoriController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public KategoriController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: Kategoris
        public async Task<IActionResult> Index()
        {
            var otelYonetDBContext = _context.Kategoriler.Include(k => k.BabaKategori);
            return View(await otelYonetDBContext.ToListAsync());
        }

        // GET: Kategoris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategori = await _context.Kategoriler
                .Include(k => k.BabaKategori)
                .FirstOrDefaultAsync(m => m.KategoriID == id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        // GET: Kategoris/Create
        public IActionResult Create()
        {
            ViewData["BabaKategoriID"] = new SelectList(_context.Kategoriler, "KategoriID", "KategoriAdı");
            return View();
        }

        // POST: Kategoris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KategoriID,KategoriAdı,BabaKategoriID")] Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategori);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BabaKategoriID"] = new SelectList(_context.Kategoriler, "KategoriID", "KategoriAdı", kategori.BabaKategoriID);
            return View(kategori);
        }

        // GET: Kategoris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategori = await _context.Kategoriler.FindAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }
            ViewData["BabaKategoriID"] = new SelectList(_context.Kategoriler, "KategoriID", "KategoriAdı", kategori.BabaKategoriID);
            return View(kategori);
        }

        // POST: Kategoris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KategoriID,KategoriAdı,BabaKategoriID")] Kategori kategori)
        {
            if (id != kategori.KategoriID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategoriExists(kategori.KategoriID))
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
            ViewData["BabaKategoriID"] = new SelectList(_context.Kategoriler, "KategoriID", "KategoriAdı", kategori.BabaKategoriID);
            return View(kategori);
        }

        // GET: Kategoris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategori = await _context.Kategoriler
                .Include(k => k.BabaKategori)
                .FirstOrDefaultAsync(m => m.KategoriID == id);
            if (kategori == null)
            {
                return NotFound();
            }

            return View(kategori);
        }

        // POST: Kategoris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategori = await _context.Kategoriler.FindAsync(id);
            _context.Kategoriler.Remove(kategori);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategoriExists(int id)
        {
            return _context.Kategoriler.Any(e => e.KategoriID == id);
        }
    }
}
