using BatmansSecretNumberBook.Core;
using BatmansSecretNumberBook.Data;
using BatmansSecretNumberBook.Exeptions;
using BatmansSecretNumberBook.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BatmansSecretNumberBook.Services.PersonServices
{
    public class PersonService : IPersonService
    {
        private readonly DataContext _context;
        public PersonService(DataContext context)
        {
            _context = context;
        }

        public Person CreatePerson(Person person)
        {
            using (var uow = new UnitOfWork(_context))
            {
                uow.Persons.Add(person);
                person = uow.Persons.FirstOrDefault(person) ?? throw new PersonNotFoundException();
                uow.Complete();
            }
            return person;
        }

        public List<Person> ReadAllPersons()
        {
            using (var uow = new UnitOfWork(_context))
            {
                return uow.Persons.GetAll().ToList();
            }
        }

        public Person ReadSinglePerson(int id)
        {
            using (var uow = new UnitOfWork(_context))
            {
                return uow.Persons.Get(id) ?? throw new PersonNotFoundException();
            }
        }

        public Person UpdatePerson(int id, Person newPerson)
        {
            Person person;
            using (var uow = new UnitOfWork(_context))
            {
                person = uow.Persons.Get(id) ?? throw new PersonNotFoundException();
                person.Update(newPerson);
                person = uow.Persons.FirstOrDefault(person) ?? throw new PersonNotFoundException();
                uow.Complete();
                return person;
            }
        }

        public Person DeletePerson(int id)
        {
            Person person;
            using (var uow = new UnitOfWork(_context))
            {
                person = uow.Persons.Get(id) ?? throw new PersonNotFoundException();
                uow.Persons.Remove(person);
                uow.Complete();
                return person;
            }
        }
    }
}
