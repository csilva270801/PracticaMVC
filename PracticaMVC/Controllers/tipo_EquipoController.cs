using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class tipo_EquipoController : Controller
    {
        private readonly equiposDbContext _context;

        public tipo_EquipoController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: tipo_Equipo
        public async Task<IActionResult> Index()
        {
              return _context.tipo_Equipo != null ? 
                          View(await _context.tipo_Equipo.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.tipo_Equipo'  is null.");
        }

        // GET: tipo_Equipo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tipo_Equipo == null)
            {
                return NotFound();
            }

            var tipo_Equipo = await _context.tipo_Equipo
                .FirstOrDefaultAsync(m => m.id_tipo_equipo == id);
            if (tipo_Equipo == null)
            {
                return NotFound();
            }

            return View(tipo_Equipo);
        }

        // GET: tipo_Equipo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tipo_Equipo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_tipo_equipo,descripcion,estado")] tipo_Equipo tipo_Equipo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipo_Equipo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipo_Equipo);
        }

        // GET: tipo_Equipo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tipo_Equipo == null)
            {
                return NotFound();
            }

            var tipo_Equipo = await _context.tipo_Equipo.FindAsync(id);
            if (tipo_Equipo == null)
            {
                return NotFound();
            }
            return View(tipo_Equipo);
        }

        // POST: tipo_Equipo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_tipo_equipo,descripcion,estado")] tipo_Equipo tipo_Equipo)
        {
            if (id != tipo_Equipo.id_tipo_equipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipo_Equipo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tipo_EquipoExists(tipo_Equipo.id_tipo_equipo))
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
            return View(tipo_Equipo);
        }

        // GET: tipo_Equipo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tipo_Equipo == null)
            {
                return NotFound();
            }

            var tipo_Equipo = await _context.tipo_Equipo
                .FirstOrDefaultAsync(m => m.id_tipo_equipo == id);
            if (tipo_Equipo == null)
            {
                return NotFound();
            }

            return View(tipo_Equipo);
        }

        // POST: tipo_Equipo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tipo_Equipo == null)
            {
                return Problem("Entity set 'equiposDbContext.tipo_Equipo'  is null.");
            }
            var tipo_Equipo = await _context.tipo_Equipo.FindAsync(id);
            if (tipo_Equipo != null)
            {
                _context.tipo_Equipo.Remove(tipo_Equipo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tipo_EquipoExists(int id)
        {
          return (_context.tipo_Equipo?.Any(e => e.id_tipo_equipo == id)).GetValueOrDefault();
        }
    }
}
