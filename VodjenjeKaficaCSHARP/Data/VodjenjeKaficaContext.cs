using Microsoft.EntityFrameworkCore;
using VodjenjeKaficaCSHARP.Models;

namespace VodjenjeKaficaCSHARP.Data
{
    /// <summary>
    /// Klasa koja predstavlja kontekst baze podataka za Kafic aplikaciju.
    /// </summary>
    public class VodjenjeKaficaContext : DbContext
    {
        /// <summary>
        /// Konstruktor klase VodjenjeKaficaContext.
        /// </summary>
        /// <param name="opcije">Zahtjevani parametar</param>
        public VodjenjeKaficaContext(DbContextOptions<VodjenjeKaficaContext> opcije) : base(opcije) {

        }
        /// <summary>
        /// Predstavlja kolekciju artikala.
        /// </summary>
        public DbSet<Artikl> Artikli { get; set; }
        /// <summary>
        /// Predstavlja kolekciju dobavljača.
        /// </summary>
        public DbSet<Dobavljac> Dobavljaci {get; set; }
        /// <summary>
        /// Predstavlja kolekciju nabavi.
        /// </summary>
        public DbSet<Nabava> Nabave { get; set; }
        /// <summary>
        /// Predstavlja kolekciju stavki.
        /// </summary>
        public DbSet<Stavka> Stavke { get; set; }
        /// <summary>
        /// Predstavlja kolekciju operatera.
        /// </summary>
        public DbSet<Operater> Operateri { get; set; }

        /// <summary>
        /// Metoda za definiranje veza između entiteta.
        /// </summary>
        /// <param name="modelBuilder">Instanca modelBuilder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Implementacija veze 1:n
            modelBuilder.Entity<Nabava>().HasOne(n => n.Dobavljac);
            // modelBuilder.Entity<Nabava>().HasMany(n => n.Stavke);
            // modelBuilder.Entity<Stavka>().HasOne(n => n.Nabava);



            // Implementacija veze n:n
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
