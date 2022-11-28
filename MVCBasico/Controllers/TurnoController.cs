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
    public class TurnoController : Controller
    {
        private readonly AdmTurnosDatabaseContext _context;

        public TurnoController(AdmTurnosDatabaseContext context)
        {
            _context = context;
        }

        // GET: Turno
        public async Task<IActionResult> Index()
        {
            ClientesDropDownList();
            TurneraDropDownList();
            return View(await _context.Turnos.ToListAsync());
        }

        // GET: Turno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .FirstOrDefaultAsync(m => m.IdTurno == id);
            if (turno == null)
            {
                return NotFound();
            }

            ClientesDropDownList(turno.IdCliente);
            TurneraDropDownList(turno.IdTurnera);

            return View(turno);
        }

        private void ClientesDropDownList(int? selectedCliente = null)
        {
            var cliente = _context.Clientes;
            ViewBag.IdCliente = new SelectList(cliente.AsNoTracking(), "IdCliente", "NombreApellidoCliente", selectedCliente);
        }
        private void TurneraDropDownList(int? selectedTurnera = null)
        {
            var turnera = _context.Turneras;
            ViewBag.IdTurnera = new SelectList(turnera.AsNoTracking(), "IdTurnera", "Nombre", selectedTurnera);
        }


        // GET: Turno/Create
        public IActionResult Create()
        {
            ClientesDropDownList();
            TurneraDropDownList();

            return View();
        }

        // POST: Turno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTurno,IdCliente,IdTurnera,FechaTurno")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                // aca busco que no haya un turno en esa fecha
                var turnoABuscar = await _context.Turnos.FirstOrDefaultAsync(m => m.FechaTurno == turno.FechaTurno);

                if (turnoABuscar != null)
                {
                    // aca entro cuando ya tengo un turno asignado
                    // return Content("El turno ya esta ocupado");
                    // retornar una vista en el viewbag.mensajeerror = "el turno ya esta ocupado"
                    ViewBag.Mensaje = "El turno ya esta ocupado";
                    return View(turno);
                }
                else
                {
                    // aca tengo que buscar al cliente para verificar el saldo
                    var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.IdCliente == turno.IdCliente);

                    if (cliente.TengoSaldo())
                    {
                        cliente.RestarSaldo(100);
                        _context.Add(turno);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewBag.Mensaje = "El cliente no tiene saldo";
                        return View(turno);
                    }

                    
                }


            }
            ClientesDropDownList();
            TurneraDropDownList();

            return View(turno);
        }

        // GET: Turno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }
            ClientesDropDownList(turno.IdCliente);
            TurneraDropDownList(turno.IdTurnera);
            return View(turno);
        }

        // POST: Turno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTurno,IdCliente,IdTurnera,FechaTurno")] Turno turno)
        {
            if (id != turno.IdTurno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoExists(turno.IdTurno))
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
            ClientesDropDownList();
            TurneraDropDownList();
            return View(turno);
        }

        // GET: Turno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .FirstOrDefaultAsync(m => m.IdTurno == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // POST: Turno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoExists(int id)
        {
            return _context.Turnos.Any(e => e.IdTurno == id);
        }
    }
}
