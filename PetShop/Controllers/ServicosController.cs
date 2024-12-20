﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShop.Data;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class ServicosController : Controller
    {
        private readonly PetShopContext _context;

        public ServicosController(PetShopContext context)
        {
            _context = context;
        }

        // GET: Servicos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Servicos.ToListAsync());
        }

        // GET: Servicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servico = await _context.Servicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servico == null)
            {
                return NotFound();
            }

            return View(servico);
        }


        // GET: Servicos/Create
        public IActionResult Create()
        {
            ViewData["TipoServicoOptions"] = new SelectList(Enum.GetValues(typeof(TipoServico)).Cast<TipoServico>());
            return View();
        }

        // POST: Servicos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,tipoServico,preco,data")] Servicos servicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoServicoOptions"] = new SelectList(Enum.GetValues(typeof(TipoServico)).Cast<TipoServico>());
            return View(servicos);
        }

        // GET: Servicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicos = await _context.Servicos.FindAsync(id);
            if (servicos == null)
            {
                return NotFound();
            }
            ViewData["TipoServicoOptions"] = new SelectList(Enum.GetValues(typeof(TipoServico)).Cast<TipoServico>());
            return View(servicos);
        }

        // POST: Servicos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,tipoServico,preco,data")] Servicos servicos)
        {
            if (id != servicos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicosExists(servicos.Id))
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
            ViewData["TipoServicoOptions"] = new SelectList(Enum.GetValues(typeof(TipoServico)).Cast<TipoServico>());
            return View(servicos);
        }

        // GET: Servicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicos = await _context.Servicos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicos == null)
            {
                return NotFound();
            }

            return View(servicos);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicos = await _context.Servicos.FindAsync(id);
            if (servicos != null)
            {
                _context.Servicos.Remove(servicos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicosExists(int id)
        {
            return _context.Servicos.Any(e => e.Id == id);
        }
    }
}