using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pablo_Yanez_Examen1.Data;
using Pablo_Yanez_Examen1.Models;

namespace Pablo_Yanez_Examen1.Controllers
{
    public class PYanezsController : Controller
    {
        private readonly Pablo_Yanez_Examen1Context _context;

        public PYanezsController(Pablo_Yanez_Examen1Context context)
        {
            _context = context;
        }

        // GET: PYanezs
        public async Task<IActionResult> Index()
        {
            return View(await _context.PYanez.ToListAsync());
        }

        // GET: PYanezs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var pYanez = await _context.PYanez.FirstOrDefaultAsync(m => m.Id == id);
            if (pYanez == null) return NotFound();

            return View(pYanez);
        }

        // GET: PYanezs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PYanezs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Edad,Sueldo,Estado,Registro")] PYanez pYanez)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pYanez);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pYanez);
        }

        // GET: PYanezs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var pYanez = await _context.PYanez.FindAsync(id);
            if (pYanez == null) return NotFound();

            return View(pYanez);
        }

        // POST: PYanezs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Edad,Sueldo,Estado,Registro")] PYanez pYanez)
        {
            if (id != pYanez.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pYanez);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PYanezExists(pYanez.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pYanez);
        }

        // GET: PYanezs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var pYanez = await _context.PYanez.FirstOrDefaultAsync(m => m.Id == id);
            if (pYanez == null) return NotFound();

            return View(pYanez);
        }

        // POST: PYanezs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pYanez = await _context.PYanez.FindAsync(id);
            if (pYanez != null) _context.PYanez.Remove(pYanez);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PYanezExists(int id)
        {
            return _context.PYanez.Any(e => e.Id == id);
        }
    }
}
