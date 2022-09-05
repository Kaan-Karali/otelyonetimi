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
    public class ProfilController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public ProfilController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: Profil
        public async Task<IActionResult> Index()
        {
            var otelYonetDBContext = _context.Profiller.Include(p => p.Kullanıcı);
            return View(await otelYonetDBContext.ToListAsync());
        }

        // GET: Profil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profil = await _context.Profiller
                .Include(p => p.Kullanıcı)
                .FirstOrDefaultAsync(m => m.ProfilID == id);
            if (profil == null)
            {
                return NotFound();
            }

            return View(profil);
        }

        // GET: Profil/Create
        public IActionResult Create()
        {
            ViewData["KullanıcıID"] = new SelectList(_context.Kullanıcılar, "KullanıcıID", "EPosta");
            return View();
        }

        // POST: Profil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProfilID,KullanıcıID,Adres,CepNO,EvNO,İşNO,Meslek,ResimDosyası")] Profil profil)
        {
            profil.ResimYolu = "uploads/" + profil.ResimDosyası.FileName;
            ModelState.Remove("ResimYolu");
            if (ModelState.IsValid)
            {
                _context.Add(profil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profil);
        }

        // GET: Profil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profil = await _context.Profiller.FindAsync(id);
            if (profil == null)
            {
                return NotFound();
            }
            ViewData["KullanıcıID"] = new SelectList(_context.Kullanıcılar, "KullanıcıID", "EPosta", profil.KullanıcıID);
            return View(profil);
        }

        // POST: Profil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfilID,KullanıcıID,Adres,CepNO,EvNO,İşNO,Meslek,ResimYolu")] Profil profil)
        {
            if (id != profil.ProfilID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfilExists(profil.ProfilID))
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
            ViewData["KullanıcıID"] = new SelectList(_context.Kullanıcılar, "KullanıcıID", "EPosta", profil.KullanıcıID);
            return View(profil);
        }

        // GET: Profil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profil = await _context.Profiller
                .Include(p => p.Kullanıcı)
                .FirstOrDefaultAsync(m => m.ProfilID == id);
            if (profil == null)
            {
                return NotFound();
            }

            return View(profil);
        }

        // POST: Profil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profil = await _context.Profiller.FindAsync(id);
            _context.Profiller.Remove(profil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfilExists(int id)
        {
            return _context.Profiller.Any(e => e.ProfilID == id);
        }
    }
}
