using CupcakeErp.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CupcakeErp.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Mapeia a classe Insumo para a tabela tb_insumo no SQL
        public DbSet<Insumo> Insumos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Insumo>().ToTable("tb_insumo");
        }
    }
}
