using BatmansSecretNumberBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BatmansSecretNumberBook.Data
{
    public class BSNBContext : DbContext
    {
        public DbSet<KontaktBuisness> KontakteBuisness { get; set; } = null!;
        public DbSet<KontaktPrivate> KontaktePrivate { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1444;Database=Telefonbuch;User Id=sa;Password=jonas123!;Encrypt=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KontaktBuisness>();
            modelBuilder.Entity<KontaktPrivate>();
        }
    }

}