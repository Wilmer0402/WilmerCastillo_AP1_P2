using Microsoft.EntityFrameworkCore;
using WilmerCastillo_AP1_P2.Models;

namespace WilmerCastillo_AP1_P2.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Combos> Combos { get; set; }

        public DbSet<CombosDetalle> CombosDetalle { get; set; }
        public DbSet<Productos> Productos { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Productos>().HasData(new List<Productos>
            {
                new Productos {ProductosId = 1, Descripcion = "Combo1", DiscoDuro = "DHCD", MemoriaRam = "16Gb", MemoriaGrafica = "4GB", Procesador = "Ryzen",Costo = 2500, Precio =3000, Existencia = 10 },
                new Productos { ProductosId = 2, Descripcion = "Combo2", DiscoDuro = "DHCD", MemoriaRam = "32Gb", MemoriaGrafica = "8GB", Procesador = "Ryzen7",Costo =4500, Precio =6000, Existencia = 5 },
            });

        }
    }
}



















