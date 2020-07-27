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
    public class ModeloesController : Controller
    {
        private readonly soporte4Context _context;

        public ModeloesController(soporte4Context context)
        {
            _context = context;
        }

        // GET: Modeloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Modelo.ToListAsync());
        }

        // GET: Modeloes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo
                .FirstOrDefaultAsync(m => m.Modelo1 == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // GET: Modeloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Modeloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdModelo,Modelo1")] Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        // GET: Modeloes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo.FindAsync(id);
            if (modelo == null)
            {
                return NotFound();
            }
            return View(modelo);
        }

        // POST: Modeloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdModelo,Modelo1")] Modelo modelo)
        {
            if (id != modelo.Modelo1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloExists(modelo.Modelo1))
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
            return View(modelo);
        }

        // GET: Modeloes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modelo = await _context.Modelo
                .FirstOrDefaultAsync(m => m.Modelo1 == id);
            if (modelo == null)
            {
                return NotFound();
            }

            return View(modelo);
        }

        // POST: Modeloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var modelo = await _context.Modelo.FindAsync(id);
            _context.Modelo.Remove(modelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloExists(string id)
        {
            return _context.Modelo.Any(e => e.Modelo1 == id);
        }
    }
}
