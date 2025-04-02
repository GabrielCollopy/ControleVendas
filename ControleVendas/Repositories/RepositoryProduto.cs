using ControleVendas.Models;

namespace ControleVendas.Repositories
{
    public class RepositoryProduto: RepositoryBase<Produto>
    {
        public RepositoryProduto(AppDbContext contexto, bool saveChanges = true) : base(contexto, saveChanges)
        {

        }
    }
}
