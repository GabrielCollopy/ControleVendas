using ControleVendas.Models;

namespace ControleVendas.Repositories
{
    public class RepositoryVenda : RepositoryBase<Venda>
    {
        public RepositoryVenda(AppDbContext contexto, bool saveChanges = true) : base(contexto, saveChanges)
        {

        }
    }
}
