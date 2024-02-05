using BatmansSecretNumberBook.Data;
using BatmansSecretNumberBook.Exeptions;
using BatmansSecretNumberBook.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BatmansSecretNumberBook.Services.PersonServices
{
    public class PersonService : IPersonServiceAsync
    {
        private readonly DataContext _context;
        public PersonService(DataContext context)
        {
            _context = context;
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            _context.Add(person);
            await _context.SaveChangesAsync();

            return await _context.Personen.FindAsync(person.Id) ?? throw new PersonNotFoundException();
        }

        public async Task<List<Person>> ReadAllPersonsAsync()
        {
            return await _context.Personen.ToListAsync();
        }

        public async Task<Person> ReadSinglePersonAsync(int id)
        {
            return await _context.Personen.FindAsync(id) ?? throw new PersonNotFoundException();
        }

        public async Task<Person> UpdatePersonAsync(int id, Person newPerson)
        {
            var person = await _context.Personen.FindAsync(id) ?? throw new PersonNotFoundException();
            person.Update(newPerson);
            await _context.SaveChangesAsync();
            return await _context.Personen.FindAsync(id) ?? throw new PersonNotFoundException();
        }

        public async Task<Person> DeletePersonAsync(int id)
        {
            var person = await _context.Personen.FindAsync(id) ?? throw new PersonNotFoundException();
            _context.Remove(person);
            await _context.SaveChangesAsync();
            return person;
        }
    }
}
