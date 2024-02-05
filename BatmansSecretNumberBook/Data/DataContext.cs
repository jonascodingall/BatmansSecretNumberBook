using Microsoft.EntityFrameworkCore;

namespace BatmansSecretNumberBook.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Person> Personen { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactPrivate> ContactsPrivate { get; set; }
        public DbSet<ContactBusiness> ContactsBusiness { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                 .HasDiscriminator<string>("ContactType")
                 .HasValue<ContactPrivate>("ContactPrivate")
                 .HasValue<ContactBusiness>("ContactBusiness");
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1444;Database=BatmansSecretNumberBook;User Id=sa;Password=jonas123!;Encrypt=False");
        }
    }
}
