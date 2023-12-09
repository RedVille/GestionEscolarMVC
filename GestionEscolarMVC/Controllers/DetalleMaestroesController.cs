using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionEscolarMVC.Models;

namespace GestionEscolarMVC.Controllers
{
    public class DetalleMaestroesController : Controller
    {
        private readonly GestionEscolarContext _context;

        public DetalleMaestroesController(GestionEscolarContext context)
        {
            _context = context;
        }

        // GET: DetalleMaestroes
        public async Task<IActionResult> Index()
        {
            if (_context.DetalleMaestros == null)
            {
                return Problem("Entity set 'GestionEscolarContext.DetalleCalifs' is null.");
            }

            var detalleMaestros = await _context.DetalleMaestros
                .Include(dc => dc.Materium)
                .Include(dc => dc.Maestro)
                .ToListAsync();

            return View(detalleMaestros);
        }

        // GET: DetalleMaestroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleMaestros == null)
            {
                return NotFound();
            }

            var detalleMaestro = await _context.DetalleMaestros
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleMaestro == null)
            {
                return NotFound();
            }

            return View(detalleMaestro);
        }

        // GET: DetalleMaestroes/Create
        public IActionResult Create()
        {
            ViewBag.Materias = new SelectList(_context.Materia, "Idmateria", "Nombre");
            ViewBag.Maestros = new SelectList(_context.Maestros, "Idmaestro", "Nombre");
            return View();
        }

        // POST: DetalleMaestroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Idmateria,Idmaestro")] DetalleMaestro detalleMaestro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleMaestro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Materias = new SelectList(_context.Materia, "Idmateria", "Nombre", detalleMaestro.Idmateria);
            ViewBag.Maestros = new SelectList(_context.Maestros, "Idmaestro", "Nombre", detalleMaestro.Idmaestro);
            return View(detalleMaestro);
        }

        // GET: DetalleMaestroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleMaestros == null)
            {
                return NotFound();
            }

            var detalleMaestro = await _context.DetalleMaestros
            .Include(dm => dm.Materium)
            .Include(dm => dm.Maestro)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleMaestro == null)
            {
                return NotFound();
            }
            return View(detalleMaestro);
        }

        // POST: DetalleMaestroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idmateria,Idmaestro")] DetalleMaestro detalleMaestro)
        {
            if (id != detalleMaestro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleMaestro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleMaestroExists(detalleMaestro.Id))
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
            return View(detalleMaestro);
        }

        // GET: DetalleMaestroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleMaestros == null)
            {
                return NotFound();
            }

            var detalleMaestro = await _context.DetalleMaestros
            .Include(dm => dm.Materium)
            .Include(dm => dm.Maestro)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleMaestro == null)
            {
                return NotFound();
            }

            return View(detalleMaestro);
        }

        // POST: DetalleMaestroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleMaestros == null)
            {
                return Problem("Entity set 'GestionEscolarContext.DetalleMaestros'  is null.");
            }
            var detalleMaestro = await _context.DetalleMaestros.FindAsync(id);
            if (detalleMaestro != null)
            {
                _context.DetalleMaestros.Remove(detalleMaestro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleMaestroExists(int id)
        {
          return (_context.DetalleMaestros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
