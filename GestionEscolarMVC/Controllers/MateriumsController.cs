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
    public class MateriumsController : Controller
    {
        private readonly GestionEscolarContext _context;

        public MateriumsController(GestionEscolarContext context)
        {
            _context = context;
        }

        // GET: Materiums
        public async Task<IActionResult> Index()
        {
              return _context.Materia != null ? 
                          View(await _context.Materia.ToListAsync()) :
                          Problem("Entity set 'GestionEscolarContext.Materia'  is null.");
        }

        // GET: Materiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Materia == null)
            {
                return NotFound();
            }

            var materium = await _context.Materia
                .FirstOrDefaultAsync(m => m.Idmateria == id);
            if (materium == null)
            {
                return NotFound();
            }

            return View(materium);
        }

        // GET: Materiums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Materiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmateria,Nombre,Descripcion,Horario")] Materium materium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materium);
        }

        // GET: Materiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Materia == null)
            {
                return NotFound();
            }

            var materium = await _context.Materia.FindAsync(id);
            if (materium == null)
            {
                return NotFound();
            }
            return View(materium);
        }

        // POST: Materiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmateria,Nombre,Descripcion,Horario")] Materium materium)
        {
            if (id != materium.Idmateria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriumExists(materium.Idmateria))
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
            return View(materium);
        }

        // GET: Materiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Materia == null)
            {
                return NotFound();
            }

            var materium = await _context.Materia
                .FirstOrDefaultAsync(m => m.Idmateria == id);
            if (materium == null)
            {
                return NotFound();
            }

            return View(materium);
        }

        // POST: Materiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Materia == null)
            {
                return Problem("Entity set 'GestionEscolarContext.Materia'  is null.");
            }
            var materium = await _context.Materia.FindAsync(id);
            if (materium != null)
            {
                _context.Materia.Remove(materium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriumExists(int id)
        {
          return (_context.Materia?.Any(e => e.Idmateria == id)).GetValueOrDefault();
        }
    }
}
