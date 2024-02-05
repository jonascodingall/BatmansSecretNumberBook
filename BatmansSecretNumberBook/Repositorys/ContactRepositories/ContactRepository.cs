using BatmansSecretNumberBook.Data;
using Microsoft.EntityFrameworkCore;

namespace BatmansSecretNumberBook.Repositorys.ContactRepositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public DataContext? DataContext
        {
            get { return _context as DataContext; }
        }
        public ContactRepository(DbContext context) : base(context)
        {
        }
    }
}
