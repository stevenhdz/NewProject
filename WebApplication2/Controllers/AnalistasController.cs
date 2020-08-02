using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AnalistasController : Controller
    {
        private readonly soporte4Context _context;

        public AnalistasController(soporte4Context context)
        {
            _context = context;
        }

        // GET: Analistas
        public async Task<IActionResult> Index()
        {
             var soporte7Context = _context.Analista.Include(a => a.RolNavigation);
            return View(await soporte7Context.ToListAsync());
        }

        // GET: Analistas/Details/5
         public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analista = await _context.Analista
                .Include(a => a.RolNavigation)
                .FirstOrDefaultAsync(m => m.NombreTecnico == id);
            if (analista == null)
            {
                return NotFound();
            }

            return View(analista);
        }

        // GET: Analistas/Create
        public IActionResult Create()
        {
            ViewData["Rol"] = new SelectList(_context.Rol, "Role", "Role");
            return View();
        }

        // POST: Analistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnalista,NombreTecnico,Rol")] Analista analista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Rol"] = new SelectList(_context.Rol, "Role", "Role", analista.Rol);
            return View(analista);
        }

        // GET: Analistas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analista = await _context.Analista.FindAsync(id);
            if (analista == null)
            {
                return NotFound();
            }
             ViewData["Rol"] = new SelectList(_context.Rol, "Role", "Role", analista.Rol);
            return View(analista);
        }

        // POST: Analistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdAnalista,NombreTecnico,Rol")] Analista analista)
        {
            if (id != analista.NombreTecnico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalistaExists(analista.NombreTecnico))
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
             ViewData["Rol"] = new SelectList(_context.Rol, "Role", "Role", analista.Rol);
            return View(analista);
        }

        // GET: Analistas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var analista = await _context.Analista
                .Include(a => a.RolNavigation)
                .FirstOrDefaultAsync(m => m.NombreTecnico == id);
            if (analista == null)
            {
                return NotFound();
            }

            return View(analista);
        }

        // POST: Analistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var analista = await _context.Analista.FindAsync(id);
            _context.Analista.Remove(analista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalistaExists(string id)
        {
            return _context.Analista.Any(e => e.NombreTecnico == id);
        }
    }
}
