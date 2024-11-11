using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class PedidosController : Controller
    {
        private readonly PetShopContext _context;

        public PedidosController(PetShopContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var pedidos = _context.Pedidos
                .Include(p => p.Servicos)
                .Include(p => p.Animais)
                .Include(p => p.Empregados);
            return View(await pedidos.ToListAsync());

        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Servicos)
                .Include(p => p.Animais)
                .Include(p => p.Empregados)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["ServicoId"] = new SelectList(_context.Servicos, "Id", "tipoServico");
            ViewData["AnimalId"] = new SelectList(_context.Animais, "Id", "nomeAnimal");
            ViewData["EmpregadoId"] = new SelectList(_context.Empregados, "Id", "NomeEmpregado");
            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicoId, AnimalId, EmpregadoId")] Pedidos pedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServicoId"] = new SelectList(_context.Servicos, "Id", "tipoServico", pedido.ServicoId);
            ViewData["AnimalId"] = new SelectList(_context.Animais, "Id", "nomeAnimal", pedido.AnimalId);
            ViewData["EmpregadoId"] = new SelectList(_context.Empregados, "Id", "NomeEmpregado", pedido.EmpregadoId);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["ServicoId"] = new SelectList(_context.Servicos, "Id", "tipoServico", pedido.ServicoId);
            ViewData["AnimalId"] = new SelectList(_context.Animais, "Id", "nomeAnimal", pedido.AnimalId);
            ViewData["EmpregadoId"] = new SelectList(_context.Empregados, "Id", "NomeEmpregado", pedido.EmpregadoId);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicoId, AnimalId, EmpregadoId")] Pedidos pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
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
            ViewData["ServicoId"] = new SelectList(_context.Servicos, "Id", "tipoServico", pedido.ServicoId);
            ViewData["AnimalId"] = new SelectList(_context.Animais, "Id", "nomeAnimal", pedido.AnimalId);
            ViewData["EmpregadoId"] = new SelectList(_context.Empregados, "Id", "NomeEmpregado", pedido.EmpregadoId);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Servicos)
                .Include(p => p.Animais)
                .Include(p => p.Empregados)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
