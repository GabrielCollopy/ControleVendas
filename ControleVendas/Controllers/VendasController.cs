using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleVendas.Models;
using ControleVendas.Services;
using ControleVendas.Helpers;

namespace ControleVendas.Controllers
{
    public class VendasController : Controller
    {
        private readonly AppDbContext _context;
        private ServiceVenda _serviceVenda;

        public VendasController(AppDbContext context)
        {
            _context = context;
            _serviceVenda = new ServiceVenda(_context);
        }

        public async Task CarregarCombos()
        {
            ViewData["produtoId"] = new SelectList(await _serviceVenda.RptProduto.ListarTodosAsync(), "Id", "nome");
            ViewData["vendedorId"] = new SelectList(await _serviceVenda.RptVendedor.ListarTodosAsync(), "Id", "cpf");
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var vendas = await _serviceVenda.RptVenda.ListarComIncludeAsync();
            return View(vendas);
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _serviceVenda.RptVenda.SelecionarComIncludeAsync(id.Value);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public async Task <IActionResult> Create()
        {
            await CarregarCombos();
            return View();
        }

        public IActionResult IndexPaginado(int pageNumber = 1, int pageSize = 2)
        {
            var listaVendas = _serviceVenda.RptVenda.ListarTodos().AsQueryable();
            var paginatedList = PaginatedList<Venda>.CreateAsync(listaVendas, pageNumber, pageSize);
            return View(paginatedList);
        }

        // POST: Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,dataVenda,vendedorId,produtoId,quantidade")] Venda venda)
        {
            await CarregarCombos();
            if (ModelState.IsValid)
            {
                ViewBag.Mensagem = "Venda cadastrada com sucesso";
                //_context.Add(venda);
                //await _context.SaveChangesAsync();
                await _serviceVenda.RptVenda.IncluirAsync(venda);
                //return RedirectToAction(nameof(Index));
                //return View(venda);
            }
            return View();
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _serviceVenda.RptVenda.SelecionarChaveAsync(id.Value);
            if (venda == null)
            {
                return NotFound();
            }
            await CarregarCombos();
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,dataVenda,vendedorId,produtoId,quantidade")] Venda venda)
        {
            if (id != venda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(venda);
                    //await _context.SaveChangesAsync();
                    await _serviceVenda.RptVenda.AlterarAsync(venda);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.Id))
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
            await CarregarCombos();
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _serviceVenda.RptVenda.SelecionarComIncludeAsync(id.Value);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var venda = await _serviceVenda.RptVenda.SelecionarChaveAsync(id);
            if (venda != null)
            {
                //_context.Vendas.Remove(venda);
                await _serviceVenda.RptVenda.ExcluirAsync(venda);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int? id)
        {
            return _context.Vendas.Any(e => e.Id == id);
        }
    }
}
