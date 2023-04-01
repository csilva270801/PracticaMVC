﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticaMVC.Models;

namespace PracticaMVC.Controllers
{
    public class estados_ReservaController : Controller
    {
        private readonly equiposDbContext _context;

        public estados_ReservaController(equiposDbContext context)
        {
            _context = context;
        }

        // GET: estados_Reserva
        public async Task<IActionResult> Index()
        {
              return _context.estados_Reserva != null ? 
                          View(await _context.estados_Reserva.ToListAsync()) :
                          Problem("Entity set 'equiposDbContext.estados_Reserva'  is null.");
        }

        // GET: estados_Reserva/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.estados_Reserva == null)
            {
                return NotFound();
            }

            var estados_Reserva = await _context.estados_Reserva
                .FirstOrDefaultAsync(m => m.estado_res_id == id);
            if (estados_Reserva == null)
            {
                return NotFound();
            }

            return View(estados_Reserva);
        }

        // GET: estados_Reserva/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: estados_Reserva/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("estado_res_id,estado")] estados_Reserva estados_Reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estados_Reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estados_Reserva);
        }

        // GET: estados_Reserva/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.estados_Reserva == null)
            {
                return NotFound();
            }

            var estados_Reserva = await _context.estados_Reserva.FindAsync(id);
            if (estados_Reserva == null)
            {
                return NotFound();
            }
            return View(estados_Reserva);
        }

        // POST: estados_Reserva/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("estado_res_id,estado")] estados_Reserva estados_Reserva)
        {
            if (id != estados_Reserva.estado_res_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estados_Reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!estados_ReservaExists(estados_Reserva.estado_res_id))
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
            return View(estados_Reserva);
        }

        // GET: estados_Reserva/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.estados_Reserva == null)
            {
                return NotFound();
            }

            var estados_Reserva = await _context.estados_Reserva
                .FirstOrDefaultAsync(m => m.estado_res_id == id);
            if (estados_Reserva == null)
            {
                return NotFound();
            }

            return View(estados_Reserva);
        }

        // POST: estados_Reserva/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.estados_Reserva == null)
            {
                return Problem("Entity set 'equiposDbContext.estados_Reserva'  is null.");
            }
            var estados_Reserva = await _context.estados_Reserva.FindAsync(id);
            if (estados_Reserva != null)
            {
                _context.estados_Reserva.Remove(estados_Reserva);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool estados_ReservaExists(int id)
        {
          return (_context.estados_Reserva?.Any(e => e.estado_res_id == id)).GetValueOrDefault();
        }
    }
}
