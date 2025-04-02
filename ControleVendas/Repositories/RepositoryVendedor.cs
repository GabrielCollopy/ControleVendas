using ControleVendas.Models;

namespace ControleVendas.Repositories
{
    public class RepositoryVendedor: RepositoryBase<Vendedor>
    {
        public RepositoryVendedor(AppDbContext contexto, bool saveChanges = true): base(contexto, saveChanges)
        {
            
        }
    }
}
