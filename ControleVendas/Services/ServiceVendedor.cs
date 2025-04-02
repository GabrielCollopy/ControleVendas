using ControleVendas.Models;
using ControleVendas.Repositories;

namespace ControleVendas.Services
{
    public class ServiceVendedor
    {
        private AppDbContext _context;
        public RepositoryVendedor RptVendedor { get; set; }
        public ServiceVendedor(AppDbContext context)
        {
            _context = context;
            RptVendedor = new RepositoryVendedor(_context);
        }
    }
}
