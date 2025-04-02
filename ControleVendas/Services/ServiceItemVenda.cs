using ControleVendas.Models;
using ControleVendas.Repositories;

namespace ControleVendas.Services
{
    public class ServiceItemVenda
    {
        private AppDbContext _context;
        public RepositoryItemVenda RptItemVenda { get; set; }
        public RepositoryProduto RptProduto { get; set; }
        public RepositoryVenda RptVenda { get; set; }

        public ServiceItemVenda(AppDbContext context)
        {
            _context = context;
            RptItemVenda = new RepositoryItemVenda(_context);
            RptProduto = new RepositoryProduto(_context);
            RptVenda = new RepositoryVenda(_context);
        }
    }
}
