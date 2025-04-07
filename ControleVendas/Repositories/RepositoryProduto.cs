using ControleVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleVendas.Repositories
{
    public class RepositoryProduto: RepositoryBase<Produto>
    {
        public RepositoryProduto(AppDbContext contexto, bool saveChanges = true) : base(contexto, saveChanges)
        {

        }

        public async Task<List<Produto>> ListarComIncludeAsync()
        {
            return await contexto.Produtos
                .ToListAsync();
        }

        public async Task<Produto?> SelecionarComIncludeAsync(int id)
        {
            return await contexto.Produtos
                .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
