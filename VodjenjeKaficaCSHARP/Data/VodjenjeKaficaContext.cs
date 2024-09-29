using Microsoft.EntityFrameworkCore;
using VodjenjeKaficaCSHARP.Models;

namespace VodjenjeKaficaCSHARP.Data
{
    public class VodjenjeKaficaContext : DbContext
    {
        public VodjenjeKaficaContext(DbContextOptions<VodjenjeKaficaContext> opcije) : base(opcije) {

        }
        public DbSet<Artikl> Artikli { get; set; }
        public DbSet<Dobavljac> Dobavljaci {get; set; }
        public DbSet<Nabava> Nabave { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nabava>().HasOne(d => d.Dobavljac);
        }

    }
}
