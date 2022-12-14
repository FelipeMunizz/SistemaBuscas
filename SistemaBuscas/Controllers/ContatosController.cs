using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaBuscas.Data;
using SistemaBuscas.Models;

namespace SistemaBuscas.Controllers
{
    public class ContatosController : Controller
    {
        private readonly AppDbContext _context;

        public ContatosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Contatos
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {

            ViewData["NomeSortParm"] = String.IsNullOrEmpty(sortOrder) ? "nome_desc" : "";
            ViewData["CategoriaSortParm"] = sortOrder == "Categoria" ? "categ_desc" : "";
            ViewData["CurrentFilter"] = searchString;
            var contatos = from s in _context.Contatos
                           select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                contatos = contatos.Where(s => s.Nome.ToUpper().ToLower().Contains(searchString)
                                       || s.Nome.ToUpper().ToLower().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "nome_desc":
                    contatos = contatos.OrderBy(s => s.Nome);
                    break;

                default:
                    contatos = contatos.OrderBy(s => s.Categoria);
                    break;
            }
            return View(await contatos.AsNoTracking().ToListAsync());
        }

        // GET: Contatos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                .FirstOrDefaultAsync(m => m.ContatoId == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // GET: Contatos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contatos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContatoId,Nome,Categoria,Residencial,Comercial,Celular")] Contato contato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        // GET: Contatos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos.FindAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        // POST: Contatos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContatoId,Nome,Categoria,Residencial,Comercial,Celular")] Contato contato)
        {
            if (id != contato.ContatoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoExists(contato.ContatoId))
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
            return View(contato);
        }

        // GET: Contatos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                .FirstOrDefaultAsync(m => m.ContatoId == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contatos == null)
            {
                return Problem("Entity set 'AppDbContext.Contatos'  is null.");
            }
            var contato = await _context.Contatos.FindAsync(id);
            if (contato != null)
            {
                _context.Contatos.Remove(contato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(int id)
        {
            return (_context.Contatos?.Any(e => e.ContatoId == id)).GetValueOrDefault();
        }
    }
}
