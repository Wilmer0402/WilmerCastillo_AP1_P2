using Microsoft.EntityFrameworkCore;
using WilmerCastillo_AP1_P2.Models;

namespace WilmerCastillo_AP1_P2.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Registros> Registros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
