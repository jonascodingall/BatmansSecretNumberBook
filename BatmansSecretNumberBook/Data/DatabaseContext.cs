using BatmansSecretNumberBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BatmansSecretNumberBook.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Personen { get; set; }
        public DbSet<KontaktPrivate> KontaktePrivat { get; set; }
        public DbSet<KontaktBusiness> KontakteBusiness { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KontaktPrivate>().ToTable("KontaktPrivate")
                                .HasOne(p => p.Person)
                                .WithMany(k => k.Kontakte)
                                .HasForeignKey(k => k.PersonId);
            modelBuilder.Entity<KontaktBusiness>().ToTable("KontaktBusiness")
                                .HasOne(p => p.Person)
                                .WithMany(k => k.Kontakte)
                                .HasForeignKey(k => k.PersonId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1444;Database=Telefonbuch;User Id=sa;Password=jonas123!;Encrypt=False");
        }
    }
}