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
    public class GarantiasController : Controller
    {
        private readonly soporte4Context _context;

        public GarantiasController(soporte4Context context)
        {
            _context = context;
        }

        // GET: Garantias
        public async Task<IActionResult> Index()
        {
            return View(await _context.Garantia.ToListAsync());
        }

        // GET: Garantias/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garantia = await _context.Garantia
                .FirstOrDefaultAsync(m => m.Garantia1 == id);
            if (garantia == null)
            {
                return NotFound();
            }

            return View(garantia);
        }

        // GET: Garantias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Garantias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdGarantia,Garantia1")] Garantia garantia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garantia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(garantia);
        }

        // GET: Garantias/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garantia = await _context.Garantia.FindAsync(id);
            if (garantia == null)
            {
                return NotFound();
            }
            return View(garantia);
        }

        // POST: Garantias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdGarantia,Garantia1")] Garantia garantia)
        {
            if (id != garantia.Garantia1)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garantia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarantiaExists(garantia.Garantia1))
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
            return View(garantia);
        }

        // GET: Garantias/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garantia = await _context.Garantia
                .FirstOrDefaultAsync(m => m.Garantia1 == id);
            if (garantia == null)
            {
                return NotFound();
            }

            return View(garantia);
        }

        // POST: Garantias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var garantia = await _context.Garantia.FindAsync(id);
            _context.Garantia.Remove(garantia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarantiaExists(string id)
        {
            return _context.Garantia.Any(e => e.Garantia1 == id);
        }
    }
}
