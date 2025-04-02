using ControleVendas.Models;
using ControleVendas.Repositories;

namespace ControleVendas.Services
{
    public class ServiceProduto
    {
        private AppDbContext _context;
        public RepositoryProduto RptProduto { get; set; }
        public ServiceProduto(AppDbContext context)
        {
            _context = context;
            RptProduto = new RepositoryProduto(_context);
        }
    }
}
