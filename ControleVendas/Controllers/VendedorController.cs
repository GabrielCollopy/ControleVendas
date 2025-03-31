using ControleVendas.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleVendas.Controllers
{
    public class VendedorController : Controller
    {
        public IActionResult Index()
        {
            var lista = new List<Vendedor>();
            lista.Add(new Vendedor()
            {
                cpf = "123.456.789-00",
                nome = "João",
                email = "joao@email.com",
                Id = 1
            });
            lista.Add(new Vendedor()
            {
                cpf = "123.456.789-01",
                nome = "Maria",
                email = "Maria@email.com",
                Id = 2
            });
            lista.Add(new Vendedor()
            {
                cpf = "123.456.789-02",
                nome = "José",
                email = "jose@email.com",
                Id = 3
            });
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Vendedor vendedor)
        {
            if (ModelState.IsValid)
            {
                ViewData["Mensagem"] = "Vendedor cadastrado com sucesso!";
                return View(vendedor);
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var lista = new List<Vendedor>();
            lista.Add(new Vendedor()
            {
                cpf = "123.456.789-00",
                nome = "João",
                email = "joao@email.com",
                Id = 1
            });
            lista.Add(new Vendedor()
            {
                cpf = "123.456.789-01",
                nome = "Maria",
                email = "Maria@email.com",
                Id = 2
            });
            lista.Add(new Vendedor()
            {
                cpf = "123.456.789-02",
                nome = "José",
                email = "jose@email.com",
                Id = 3
            });
            var vendedor = (from p in lista where p.Id == id select p).FirstOrDefault();
            return View(vendedor);
        }
    }
}
