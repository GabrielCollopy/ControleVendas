using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleVendas.Models;
using ControleVendas.Services;

namespace ControleVendas.Controllers
{
    public class VendedorController : Controller
    {
        private readonly AppDbContext _context;
        private ServiceVendedor _serviceVendedor;

        public VendedorController(AppDbContext context)
        {
            _context = context;
            _serviceVendedor = new ServiceVendedor(_context);
        }

        // GET: Vendedor
        public async Task<IActionResult> Index()
        {
            var vendedores = await _serviceVendedor.RptVendedor.ListarTodosAsync();
            return View(vendedores);
        }

        // GET: Vendedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        // GET: Vendedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vendedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,cpf,email")] Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(vendedor);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                ViewBag.Mensagem = "Venda cadastrada com sucesso";
                await _serviceVendedor.RptVendedor.IncluirAsync(vendedor);
            }
            return View(vendedor);
        }

        // GET: Vendedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _serviceVendedor.RptVendedor.SelecionarChaveAsync(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            return View(vendedor);
        }

        // POST: Vendedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,nome,cpf,email")] Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(vendedor);
                    //await _context.SaveChangesAsync();
                    await _serviceVendedor.RptVendedor.AlterarAsync(vendedor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendedorExists(vendedor.Id))
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
            return View(vendedor);
        }

        // GET: Vendedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendedor = await _context.Vendedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vendedor == null)
            {
                return NotFound();
            }

            return View(vendedor);
        }

        // POST: Vendedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var vendedor = await _serviceVendedor.RptVendedor.SelecionarChaveAsync(id);
            if (vendedor != null)
            {
                await _serviceVendedor.RptVendedor.ExcluirAsync(vendedor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendedorExists(int? id)
        {
            return _context.Vendedores.Any(e => e.Id == id);
        }
    }
}
