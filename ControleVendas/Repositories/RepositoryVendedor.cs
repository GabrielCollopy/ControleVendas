using ControleVendas.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleVendas.Repositories
{
    public class RepositoryVendedor: RepositoryBase<Vendedor>
    {
        public RepositoryVendedor(AppDbContext contexto, bool saveChanges = true): base(contexto, saveChanges)
        {
            
        }

        public async Task<List<Vendedor>> ListarComIncludeAsync()
        {
            return await contexto.Vendedores
                .ToListAsync();
        }

        public async Task<Vendedor?> SelecionarComIncludeAsync(int id)
        {
            return await contexto.Vendedores
                .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
