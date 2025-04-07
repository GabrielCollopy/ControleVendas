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
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;
        private ServiceProduto _serviceProduto;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
            _serviceProduto = new ServiceProduto(_context);
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            var produtos = await _serviceProduto.RptProduto.ListarTodosAsync();
            return View(produtos);
        }

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _serviceProduto.RptProduto.SelecionarComIncludeAsync(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,preco,quantidade")] Produto produto)
        {
            if (ModelState.IsValid)
            {

                //_context.Add(produto);
                ViewBag.Mensagem = "Produto cadastrado com sucesso";
                await _serviceProduto.RptProduto.IncluirAsync(produto);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _serviceProduto.RptProduto.SelecionarChaveAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,nome,preco,quantidade")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(produto);
                    //await _context.SaveChangesAsync();
                    await _serviceProduto.RptProduto.AlterarAsync(produto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
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
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _serviceProduto.RptProduto.SelecionarComIncludeAsync(id.Value);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var produto = await _serviceProduto.RptProduto.SelecionarChaveAsync(id);
            if (produto != null)
            {
                //_context.Produtos.Remove(produto);
                await _serviceProduto.RptProduto.ExcluirAsync(produto);
            }

            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int? id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
