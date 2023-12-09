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
    public class DetalleCalifsController : Controller
    {
        private readonly GestionEscolarContext _context;

        public DetalleCalifsController(GestionEscolarContext context)
        {
            _context = context;
        }

        // GET: DetalleCalifs
        public async Task<IActionResult> Index()
        {
            if (_context.DetalleCalifs == null)
            {
                return Problem("Entity set 'GestionEscolarContext.DetalleCalifs' is null.");
            }

            var detalleCalifs = await _context.DetalleCalifs
                .Include(dc => dc.Alumno)
                .Include(dc => dc.Materium)
                .ToListAsync();

            return View(detalleCalifs);
        }

        // GET: DetalleCalifs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleCalifs == null)
            {
                return NotFound();
            }

            var detalleCalif = await _context.DetalleCalifs
            .Include(dc => dc.Alumno)
            .Include(dc => dc.Materium)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleCalif == null)
            {
                return NotFound();
            }

            return View(detalleCalif);
        }

        // GET: DetalleCalifs/Create
        public IActionResult Create()
        {
            ViewBag.Alumnos = new SelectList(_context.Alumnos, "Idalumno", "Nombre");
            ViewBag.Materias = new SelectList(_context.Materia, "Idmateria", "Nombre");

            return View();
        }

        // POST: DetalleCalifs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Idmateria,Idalumno,Calif1,Calif2,Calif3")] DetalleCalif detalleCalif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleCalif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Alumnos = new SelectList(_context.Alumnos, "Idalumno", "Nombre", detalleCalif.Idalumno);
            ViewBag.Materias = new SelectList(_context.Materia, "Idmateria", "Nombre", detalleCalif.Idmateria);

            return View(detalleCalif);
        }

        // GET: DetalleCalifs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleCalifs == null)
            {
                return NotFound();
            }

            var detalleCalif = await _context.DetalleCalifs
            .Include(dc => dc.Alumno)
            .Include(dc => dc.Materium)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleCalif == null)
            {
                return NotFound();
            }
            return View(detalleCalif);
        }

        // POST: DetalleCalifs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Idmateria,Idalumno,Calif1,Calif2,Calif3")] DetalleCalif detalleCalif)
        {
            if (id != detalleCalif.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleCalif);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleCalifExists(detalleCalif.Id))
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
            return View(detalleCalif);
        }

        // GET: DetalleCalifs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleCalifs == null)
            {
                return NotFound();
            }

            var detalleCalif = await _context.DetalleCalifs
            .Include(dc => dc.Alumno)
            .Include(dc => dc.Materium)
            .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleCalif == null)
            {
                return NotFound();
            }

            return View(detalleCalif);
        }

        // POST: DetalleCalifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleCalifs == null)
            {
                return Problem("Entity set 'GestionEscolarContext.DetalleCalifs'  is null.");
            }
            var detalleCalif = await _context.DetalleCalifs.FindAsync(id);
            if (detalleCalif != null)
            {
                _context.DetalleCalifs.Remove(detalleCalif);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleCalifExists(int id)
        {
          return (_context.DetalleCalifs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
