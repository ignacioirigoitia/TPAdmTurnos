using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBasico.Context;
using MVCBasico.Models;

namespace MVCBasico.Controllers
{
    public class TurneraController : Controller
    {
        private readonly AdmTurnosDatabaseContext _context;

        public TurneraController(AdmTurnosDatabaseContext context)
        {
            _context = context;
        }

        // GET: Turnera
        public async Task<IActionResult> Index()
        {
            return View(await _context.Turneras.ToListAsync());
        }

        // GET: Turnera/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnera = await _context.Turneras
                .FirstOrDefaultAsync(m => m.IdTurnera == id);
            if (turnera == null)
            {
                return NotFound();
            }

            return View(turnera);
        }

        // GET: Turnera/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turnera/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTurnera,Nombre")] Turnera turnera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turnera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(turnera);
        }

        // GET: Turnera/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnera = await _context.Turneras.FindAsync(id);
            if (turnera == null)
            {
                return NotFound();
            }
            return View(turnera);
        }

        // POST: Turnera/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTurnera,Nombre")] Turnera turnera)
        {
            if (id != turnera.IdTurnera)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turnera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurneraExists(turnera.IdTurnera))
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
            return View(turnera);
        }

        // GET: Turnera/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turnera = await _context.Turneras
                .FirstOrDefaultAsync(m => m.IdTurnera == id);
            if (turnera == null)
            {
                return NotFound();
            }

            return View(turnera);
        }

        // POST: Turnera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turnera = await _context.Turneras.FindAsync(id);
            _context.Turneras.Remove(turnera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurneraExists(int id)
        {
            return _context.Turneras.Any(e => e.IdTurnera == id);
        }
    }
}
