using BatmansSecretNumberBook.Data;
using Microsoft.EntityFrameworkCore;

namespace BatmansSecretNumberBook.Repositorys.PersonRepositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public DataContext? DataContext
        {
            get { return _context as DataContext; }
        }
        public PersonRepository(DbContext context) : base(context)
        {
        }

        public Person? FirstOrDefault(Person person)
        {
            return _context.Set<Person>().FirstOrDefault(person);
        }
    }
}
