using Microsoft.EntityFrameworkCore;

namespace ControleVendas.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Venda>()
                .HasOne(v => v.Vendedor)
                .WithMany()
                .HasForeignKey(v => v.vendedorId);

            modelBuilder.Entity<ItemVenda>()
                .HasOne(v => v.Venda)
                .WithMany()
                .HasForeignKey(v => v.vendaId);

            modelBuilder.Entity<ItemVenda>()
                .HasOne(v => v.Produto)
                .WithMany()
                .HasForeignKey(v => v.produtoId);
        }
    }
}
