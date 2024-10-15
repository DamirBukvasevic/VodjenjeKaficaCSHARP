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
        public DbSet<Stavka> Stavke { get; set; }
        public DbSet<Operater> Operateri { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nabava>().HasOne(n => n.Dobavljac);
            // modelBuilder.Entity<Nabava>().HasMany(n => n.Stavke);
            // modelBuilder.Entity<Stavka>().HasOne(n => n.Nabava);




            modelBuilder.Entity<Stavka>(entity =>
            {
                entity.HasOne(d => d.Nabava)
                    .WithMany(p => p.Stavke);



                entity.HasOne(d => d.Artikl)
                    .WithMany(p => p.Stavke);


            });



            /*
            modelBuilder.Entity<Nabava>()
                .HasMany(n => n.Stavke)
                .WithMany(a => a.Nabave)
                .UsingEntity<Dictionary<string, object>>("stavke",
                c => c.HasOne<Artikl>().WithMany().HasForeignKey("artikl"),
                c => c.HasOne<Nabava>().WithMany().HasForeignKey("nabava"),
                c => c.ToTable("stavke")
                );
            */
        }

    }
}
