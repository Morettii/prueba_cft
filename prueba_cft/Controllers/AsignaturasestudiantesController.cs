using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba_cft.Models;

namespace prueba_cft.Controllers
{
    public class AsignaturasestudiantesController : Controller
    {
        private readonly PruebaCftContext _context;

        public AsignaturasestudiantesController(PruebaCftContext context)
        {
            _context = context;
        }

        // GET: Asignaturasestudiantes
        public async Task<IActionResult> Index()
        {
            var pruebaCftContext = _context.Asignaturasestudiantes.Include(a => a.Asignatura).Include(a => a.Estudiante);
            return View(await pruebaCftContext.ToListAsync());
        }

        // GET: Asignaturasestudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asignaturasestudiantes == null)
            {
                return NotFound();
            }

            var asignaturasestudiante = await _context.Asignaturasestudiantes
                .Include(a => a.Asignatura)
                .Include(a => a.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (asignaturasestudiante == null)
            {
                return NotFound();
            }

            return View(asignaturasestudiante);
        }

        // GET: Asignaturasestudiantes/Create
        public IActionResult Create()
        {
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Id");
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id");
            return View();
        }

        // POST: Asignaturasestudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstudianteId,AsignaturaId,Id,FechaRegistro")] Asignaturasestudiante asignaturasestudiante)
        {
            if (asignaturasestudiante.EstudianteId != 0 && asignaturasestudiante.AsignaturaId != 0)
            {
                _context.Add(asignaturasestudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Id", asignaturasestudiante.AsignaturaId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id", asignaturasestudiante.EstudianteId);
            return View(asignaturasestudiante);
        }

        // GET: Asignaturasestudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asignaturasestudiantes == null)
            {
                return NotFound();
            }

            var asignaturasestudiante = await _context.Asignaturasestudiantes.FindAsync(id);
            if (asignaturasestudiante == null)
            {
                return NotFound();
            }
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Id", asignaturasestudiante.AsignaturaId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id", asignaturasestudiante.EstudianteId);
            return View(asignaturasestudiante);
        }

        // POST: Asignaturasestudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstudianteId,AsignaturaId,Id,FechaRegistro")] Asignaturasestudiante asignaturasestudiante)
        {
            if (id != asignaturasestudiante.Id)
            {
                return NotFound();
            }

            if (asignaturasestudiante.EstudianteId != 0 && asignaturasestudiante.AsignaturaId != 0)
            {
                try
                {
                    _context.Update(asignaturasestudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignaturasestudianteExists(asignaturasestudiante.Id))
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
            ViewData["AsignaturaId"] = new SelectList(_context.Asignaturas, "Id", "Id", asignaturasestudiante.AsignaturaId);
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Id", asignaturasestudiante.EstudianteId);
            return View(asignaturasestudiante);
        }

        // GET: Asignaturasestudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignaturasestudiante = await _context.Asignaturasestudiantes
                .Include(a => a.Asignatura)
                .Include(a => a.Estudiante)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (asignaturasestudiante == null)
            {
                return NotFound();
            }

            return View(asignaturasestudiante);
        }

        // POST: Asignaturasestudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignaturasestudiante = await _context.Asignaturasestudiantes.FindAsync(id);
            if (asignaturasestudiante != null)
            {
                _context.Asignaturasestudiantes.Remove(asignaturasestudiante);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AsignaturasestudianteExists(int id)
        {
            return _context.Asignaturasestudiantes.Any(e => e.Id == id);
        }
    }
}