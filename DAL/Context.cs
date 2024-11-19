using Microsoft.EntityFrameworkCore;
using WilmerCastillo_AP1_P2.Models;

namespace WilmerCastillo_AP1_P2.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Combo1> Combo1 { get; set; }
        public DbSet<ComboDetalles> ComboDetalles { get; set; }
        public DbSet<Product> Product { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
            new Product(){ProductosId = 1, Descripcion = "Disco Duro", Costo = 1000, Precio = 1500, Existencia = 20},
            new Product(){ProductosId = 2, Descripcion = "Memoria Ram", Costo = 800, Precio = 2200, Existencia = 30},
            new Product(){ProductosId = 3, Descripcion = "Procesador", Costo = 3000, Precio = 3810, Existencia = 50},
            new Product(){ProductosId = 4, Descripcion = "Memoria Grafica", Costo = 1310, Precio = 2530, Existencia = 40}
            });

        }
    }
}



















