using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
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
        public DbSet<Stavka> Stavke { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nabava>().HasOne(n => n.Dobavljac);

            modelBuilder.Entity<Nabava>()
                .HasMany(a => a.Artikli)
                .WithMany(n => n.Nabave)
                .UsingEntity<Dictionary<string, object>>("stavke",
                c => c.HasOne<Artikl>().WithMany().HasForeignKey("artikli"),
                c => c.HasOne<Nabava>().WithMany().HasForeignKey("nabava"),
                c => c.ToTable("stavke")
                );
        }

    }
}
