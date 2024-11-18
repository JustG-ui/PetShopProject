using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Controllers
{
    public class EmpregadosController : Controller
    {
        private readonly PetShopContext _context;

        public EmpregadosController(PetShopContext context)
        {
            _context = context;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empregados.ToListAsync());
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregados = await _context.Empregados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empregados == null)
            {
                return NotFound();
            }

            return View(empregados);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeEmpregado,Funcao,dataAdmissao")] Empregados empregados)
        {
            if (empregados.dataAdmissao > DateOnly.FromDateTime(DateTime.Now))
            {
                ModelState.AddModelError("dataAdmissao", "Data de admissão não pode ser no futuro.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(empregados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empregados);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregados = await _context.Empregados.FindAsync(id);
            if (empregados == null)
            {
                return NotFound();
            }
            return View(empregados);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeEmpregado,Funcao,dataAdmissao")] Empregados empregados)
        {
            if (id != empregados.Id)
            {
                return NotFound();
            }

            if (empregados.dataAdmissao > DateOnly.FromDateTime(DateTime.Now))
            {
                ModelState.AddModelError("dataAdmissao", "Data de admissão não pode ser no futuro.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empregados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpregadosExists(empregados.Id))
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
            return View(empregados);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empregados = await _context.Empregados
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empregados == null)
            {
                return NotFound();
            }

            return View(empregados);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empregados = await _context.Empregados.FindAsync(id);
            if (empregados != null)
            {
                _context.Empregados.Remove(empregados);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpregadosExists(int id)
        {
            return _context.Empregados.Any(e => e.Id == id);
        }
    }
}
