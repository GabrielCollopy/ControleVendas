using ControleVendas.Models;

namespace ControleVendas.Repositories
{
    public class RepositoryItemVenda : RepositoryBase<ItemVenda>
    {
        public RepositoryItemVenda(AppDbContext contexto, bool saveChanges = true) : base(contexto, saveChanges)
        {

        }
    }
}
