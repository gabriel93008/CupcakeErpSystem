using CupcakeErp.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CupcakeErp.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Mapeando todas as nossas classes
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Cupcake> Cupcakes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ReceitaInsumo> ReceitasInsumos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ligando as classes com os nomes exatos das tabelas no SQL
            modelBuilder.Entity<Insumo>().ToTable("tb_insumo");
            modelBuilder.Entity<Cupcake>().ToTable("tb_cupcake");
            modelBuilder.Entity<Pedido>().ToTable("tb_pedido");
            modelBuilder.Entity<ReceitaInsumo>().ToTable("tb_receita_insumo");
        }
    }
}
