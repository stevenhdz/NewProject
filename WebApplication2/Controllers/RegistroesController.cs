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
    public class RegistroesController : Controller
    {
        private readonly soporte4Context _context;

        public RegistroesController(soporte4Context context)
        {
            _context = context;
        }

        // GET: Registroes
        public async Task<IActionResult> Index()
        {
            var soporte4Context = _context.Registro.Include(r => r.CategoriaNavigation).Include(r => r.GarantiaNavigation).Include(r => r.MarcaNavigation).Include(r => r.ModeloNavigation).Include(r => r.NombreTecnicoNavigation);
            return View(await soporte4Context.ToListAsync());
        }

        // GET: Registroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registro
                .Include(r => r.CategoriaNavigation)
                .Include(r => r.GarantiaNavigation)
                .Include(r => r.MarcaNavigation)
                .Include(r => r.ModeloNavigation)
                .Include(r => r.NombreTecnicoNavigation)
                .FirstOrDefaultAsync(m => m.IdRegistro == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // GET: Registroes/Create
        public IActionResult Create()
        {
            ViewData["Categoria"] = new SelectList(_context.Categoria, "Categoria1", "Categoria1");
            ViewData["Garantia"] = new SelectList(_context.Garantia, "Garantia1", "Garantia1");
            ViewData["Marca"] = new SelectList(_context.Marca, "Marca1", "Marca1");
            ViewData["Modelo"] = new SelectList(_context.Modelo, "Modelo1", "Modelo1");
            ViewData["NombreTecnico"] = new SelectList(_context.Analista, "NombreTecnico", "NombreTecnico");
            return View();
        }

        // POST: Registroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistro,Nombre,Apellido,Numero,Direccion,FechaEntrada,FechaSalida,ValorUnidad,ValorTotal,CantidadEquipos,Seriales,Correo,Datos,Descripcion,DescripcionRespuesta,Garantia,NombreTecnico,Marca,Modelo,Categoria,Estado,ProfilePicture")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoria"] = new SelectList(_context.Categoria, "Categoria1", "Categoria1", registro.Categoria);
            ViewData["Garantia"] = new SelectList(_context.Garantia, "Garantia1", "Garantia1", registro.Garantia);
            ViewData["Marca"] = new SelectList(_context.Marca, "Marca1", "Marca1", registro.Marca);
            ViewData["Modelo"] = new SelectList(_context.Modelo, "Modelo1", "Modelo1", registro.Modelo);
            ViewData["NombreTecnico"] = new SelectList(_context.Analista, "NombreTecnico", "NombreTecnico", registro.NombreTecnico);
            return View(registro);
        }

        // GET: Registroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registro.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }
            ViewData["Categoria"] = new SelectList(_context.Categoria, "Categoria1", "Categoria1", registro.Categoria);
            ViewData["Garantia"] = new SelectList(_context.Garantia, "Garantia1", "Garantia1", registro.Garantia);
            ViewData["Marca"] = new SelectList(_context.Marca, "Marca1", "Marca1", registro.Marca);
            ViewData["Modelo"] = new SelectList(_context.Modelo, "Modelo1", "Modelo1", registro.Modelo);
            ViewData["NombreTecnico"] = new SelectList(_context.Analista, "NombreTecnico", "NombreTecnico", registro.NombreTecnico);
            return View(registro);
        }

        // POST: Registroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistro,Nombre,Apellido,Numero,Direccion,FechaEntrada,FechaSalida,ValorUnidad,ValorTotal,CantidadEquipos,Seriales,Correo,Datos,Descripcion,DescripcionRespuesta,Garantia,NombreTecnico,Marca,Modelo,Categoria,Estado,ProfilePicture")] Registro registro)
        {
            if (id != registro.IdRegistro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroExists(registro.IdRegistro))
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
            ViewData["Categoria"] = new SelectList(_context.Categoria, "Categoria1", "Categoria1", registro.Categoria);
            ViewData["Garantia"] = new SelectList(_context.Garantia, "Garantia1", "Garantia1", registro.Garantia);
            ViewData["Marca"] = new SelectList(_context.Marca, "Marca1", "Marca1", registro.Marca);
            ViewData["Modelo"] = new SelectList(_context.Modelo, "Modelo1", "Modelo1", registro.Modelo);
            ViewData["NombreTecnico"] = new SelectList(_context.Analista, "NombreTecnico", "NombreTecnico", registro.NombreTecnico);
            return View(registro);
        }

        // GET: Registroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registro
                .Include(r => r.CategoriaNavigation)
                .Include(r => r.GarantiaNavigation)
                .Include(r => r.MarcaNavigation)
                .Include(r => r.ModeloNavigation)
                .Include(r => r.NombreTecnicoNavigation)
                .FirstOrDefaultAsync(m => m.IdRegistro == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // POST: Registroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registro = await _context.Registro.FindAsync(id);
            _context.Registro.Remove(registro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroExists(int id)
        {
            return _context.Registro.Any(e => e.IdRegistro == id);
        }
    }
}
