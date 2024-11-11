using Microsoft.EntityFrameworkCore;
using ExamenBazar.Models;

namespace ExamenBazar.Data
{
    public class BazarDbContext : DbContext
    {
        public BazarDbContext(DbContextOptions<BazarDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para que la propiedad Images sea almacenada como JSON en la base de datos
            modelBuilder.Entity<Product>()
                .Property(p => p.Images)
                .HasConversion(
                    v => string.Join(",", v), // Convierte de List<string> a una sola cadena separada por comas
                    v => v.Split(",", StringSplitOptions.RemoveEmptyEntries).ToList() // Convierte de cadena a List<string>
                );

            modelBuilder.Entity<Sale>()
      .HasOne(s => s.Product)
      .WithMany(p => p.Sales)
      .HasForeignKey(s => s.ProductId)
      .OnDelete(DeleteBehavior.Cascade);


        }
    }
}