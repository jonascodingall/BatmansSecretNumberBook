using BatmansSecretNumberBook.Data;
using BatmansSecretNumberBook.Repositorys.ContactRepositories;
using BatmansSecretNumberBook.Repositorys.PersonRepositories;

namespace BatmansSecretNumberBook.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IPersonRepository Persons { get; private set; }

        public IContactRepository Contacts { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Persons = new PersonRepository(_context);
            Contacts = new ContactRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
