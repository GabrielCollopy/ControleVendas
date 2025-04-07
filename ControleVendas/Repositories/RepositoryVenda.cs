using ControleVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleVendas.Repositories
{
    public class RepositoryVenda : RepositoryBase<Venda>
    {
        public RepositoryVenda(AppDbContext contexto, bool saveChanges = true) : base(contexto, saveChanges)
        {

        }

        public async Task<List<Venda>> ListarComIncludeAsync()
        {
            return await contexto.Vendas
                .Include(v => v.Produto)
                .Include(v => v.Vendedor)
                .ToListAsync();
        }

        public async Task<Venda?> SelecionarComIncludeAsync(int id)
        {
            return await contexto.Vendas
                .Include(v => v.Produto)
                .Include(v => v.Vendedor)
                .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
