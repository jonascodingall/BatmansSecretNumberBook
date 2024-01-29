using BatmansSecretNumberBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BatmansSecretNumberBook.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Personen { get; set; }
        public DbSet<Kontakt> Kontakte { get; set; }
        public DbSet<KontaktPrivate> KontaktePrivat { get; set; }
        public DbSet<KontaktBusiness> KontakteBusiness { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kontakt>()
                 .HasDiscriminator<string>("KontaktType")
                 .HasValue<KontaktPrivate>("KontaktPrivate")
                 .HasValue<KontaktBusiness>("KontaktBusiness");
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1444;Database=Telefonbuch;User Id=sa;Password=jonas123!;Encrypt=False");
        }
    }
}
