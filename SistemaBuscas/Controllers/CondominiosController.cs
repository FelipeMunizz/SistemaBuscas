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
    public class CondominiosController : Controller
    {
        private readonly AppDbContext _context;

        public CondominiosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Condominios
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {

            ViewData["NomeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nome_desc" : "";
            ViewData["CategoriaSortParm"] = sortOrder == "Categoria" ? "categ_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            var condominios = from s in _context.Condominios
                           select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                condominios = condominios.Where(s => s.Nome.ToUpper().ToLower().Contains(searchString)
                                       || s.Nome.ToUpper().ToLower().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "nome_desc":
                    condominios = condominios.OrderByDescending(s => s.Nome);
                    break;

                default:
                    condominios = condominios.OrderBy(s => s.Nome);
                    break;
            }
            return View(await condominios.AsNoTracking().ToListAsync());
        }

        // GET: Condominios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Condominios == null)
            {
                return NotFound();
            }

            var condominio = await _context.Condominios
                .FirstOrDefaultAsync(m => m.CondominioId == id);
            if (condominio == null)
            {
                return NotFound();
            }

            return View(condominio);
        }

        // GET: Condominios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Condominios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CondominioId,Nome,Endereco,Complemento,CEP,TelAdm,Email,TelPort,TelZela,SenhaBoletos")] Condominio condominio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condominio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condominio);
        }

        // GET: Condominios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Condominios == null)
            {
                return NotFound();
            }

            var condominio = await _context.Condominios.FindAsync(id);
            if (condominio == null)
            {
                return NotFound();
            }
            return View(condominio);
        }

        // POST: Condominios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CondominioId,Nome,Endereco,Complemento,CEP,TelAdm,Email,TelPort,TelZela,SenhaBoletos")] Condominio condominio)
        {
            if (id != condominio.CondominioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condominio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondominioExists(condominio.CondominioId))
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
            return View(condominio);
        }

        // GET: Condominios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Condominios == null)
            {
                return NotFound();
            }

            var condominio = await _context.Condominios
                .FirstOrDefaultAsync(m => m.CondominioId == id);
            if (condominio == null)
            {
                return NotFound();
            }

            return View(condominio);
        }

        // POST: Condominios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Condominios == null)
            {
                return Problem("Entity set 'AppDbContext.Condominios'  is null.");
            }
            var condominio = await _context.Condominios.FindAsync(id);
            if (condominio != null)
            {
                _context.Condominios.Remove(condominio);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondominioExists(int id)
        {
          return (_context.Condominios?.Any(e => e.CondominioId == id)).GetValueOrDefault();
        }
    }
}
