using BatmansSecretNumberBook.Data;
using BatmansSecretNumberBook.Exeptions;
using BatmansSecretNumberBook.Mappers;
using Microsoft.EntityFrameworkCore;

namespace BatmansSecretNumberBook.Services.PersonServices
{
    public class PersonService : IPersonServiceAsync
    {
        private readonly DatabaseContext _contex;
        public PersonService(DatabaseContext context)
        {
            _contex = context;
        }

        public async Task<Person> CreatePersonAsync(Person person)
        {
            _contex.Add(person);
            await _contex.SaveChangesAsync();

            return _contex.Personen.FirstOrDefault(person);
        }

        public async Task<List<Person>> ReadAllPersonsAsync()
        {
            return await _contex.Personen.ToListAsync();
        }

        public async Task<Person> ReadSinglePersonAsync(int id)
        {
            return await _contex.Personen.FindAsync(id) ?? throw new PersonNotFoundExeption();
        }

        public async Task<Person> UpdatePersonAsync(int id, Person newPerson)
        {
            var person = await _contex.Personen.FindAsync(id) ?? throw new PersonNotFoundExeption();
            person.Update(newPerson);
            return person;
        }

        public async Task<Person> DeletePersonAsync(int id)
        {
            var person = await _contex.Personen.FindAsync(id) ?? throw new PersonNotFoundExeption();
            _contex.Remove(person);
            return person;
        }
    }
}
