using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pablo_Yanez_Examen1.Data;
using Pablo_Yanez_Examen1.Models;

namespace Pablo_Yanez_Examen1.Controllers
{
    public class CelularsController : Controller
    {
        private readonly Pablo_Yanez_Examen1Context _context;

        public CelularsController(Pablo_Yanez_Examen1Context context)
        {
            _context = context;
        }

        // GET: Celulars
        public async Task<IActionResult> Index()
        {
            var pablo_Yanez_Examen1Context = _context.Celular.Include(c => c.pYanez);
            return View(await pablo_Yanez_Examen1Context.ToListAsync());
        }

        // GET: Celulars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celular
                .Include(c => c.pYanez)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celular == null)
            {
                return NotFound();
            }

            return View(celular);
        }

        // GET: Celulars/Create
        public IActionResult Create()
        {
            ViewData["PYanezId"] = new SelectList(_context.PYanez, "Id", "Name");
            return View();
        }

        // POST: Celulars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Año,Precio,PYanezId")] Celular celular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(celular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PYanezId"] = new SelectList(_context.PYanez, "Id", "Name", celular.PYanezId);
            return View(celular);
        }

        // GET: Celulars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celular.FindAsync(id);
            if (celular == null)
            {
                return NotFound();
            }
            ViewData["PYanezId"] = new SelectList(_context.PYanez, "Id", "Name", celular.PYanezId);
            return View(celular);
        }

        // POST: Celulars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Año,Precio,PYanezId")] Celular celular)
        {
            if (id != celular.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(celular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CelularExists(celular.Id))
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
            ViewData["PYanezId"] = new SelectList(_context.PYanez, "Id", "Name", celular.PYanezId);
            return View(celular);
        }

        // GET: Celulars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var celular = await _context.Celular
                .Include(c => c.pYanez)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (celular == null)
            {
                return NotFound();
            }

            return View(celular);
        }

        // POST: Celulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var celular = await _context.Celular.FindAsync(id);
            if (celular != null)
            {
                _context.Celular.Remove(celular);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CelularExists(int id)
        {
            return _context.Celular.Any(e => e.Id == id);
        }
    }
}
