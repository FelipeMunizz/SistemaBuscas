using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaBuscas.Data;
using SistemaBuscas.Models;

namespace SistemaBuscas.Controllers
{
    public class DebitosController : Controller
    {
        private readonly AppDbContext _context;

        public DebitosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Debitos
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NomeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nome_desc" : "";
            ViewData["CategoriaSortParm"] = sortOrder == "Empresa" ? "empresa_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            var debitos = from s in _context.Debitos
                           select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                debitos = debitos.Where(s => s.Imovel.ToUpper().ToLower().Contains(searchString)
                                       || s.Imovel.ToUpper().ToLower().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "nome_desc":
                    debitos = debitos.OrderByDescending(s => s.Imovel);
                    break;

                default:
                    debitos = debitos.OrderBy(s => s.Imovel);
                    break;
            }
            return View(await debitos.AsNoTracking().ToListAsync());
        }

        // GET: Debitos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Debitos == null)
            {
                return NotFound();
            }

            var debito = await _context.Debitos
                .FirstOrDefaultAsync(m => m.DebitoId == id);
            if (debito == null)
            {
                return NotFound();
            }

            return View(debito);
        }

        // GET: Debitos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Debitos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DebitoId,Imovel,Empresa,Servico,NumeroDeb")] Debito debito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(debito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(debito);
        }

        // GET: Debitos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Debitos == null)
            {
                return NotFound();
            }

            var debito = await _context.Debitos.FindAsync(id);
            if (debito == null)
            {
                return NotFound();
            }
            return View(debito);
        }

        // POST: Debitos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DebitoId,Imovel,Empresa,Servico,NumeroDeb")] Debito debito)
        {
            if (id != debito.DebitoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(debito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DebitoExists(debito.DebitoId))
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
            return View(debito);
        }

        // GET: Debitos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Debitos == null)
            {
                return NotFound();
            }

            var debito = await _context.Debitos
                .FirstOrDefaultAsync(m => m.DebitoId == id);
            if (debito == null)
            {
                return NotFound();
            }

            return View(debito);
        }

        // POST: Debitos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Debitos == null)
            {
                return Problem("Entity set 'AppDbContext.Debitos'  is null.");
            }
            var debito = await _context.Debitos.FindAsync(id);
            if (debito != null)
            {
                _context.Debitos.Remove(debito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DebitoExists(int id)
        {
          return (_context.Debitos?.Any(e => e.DebitoId == id)).GetValueOrDefault();
        }
    }
}
