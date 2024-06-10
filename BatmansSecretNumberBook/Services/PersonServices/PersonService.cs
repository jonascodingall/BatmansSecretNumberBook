using BatmansSecretNumberBook.Data;
using BatmansSecretNumberBook.Exeptions;
using BatmansSecretNumberBook.Mappers;
using BatmansSecretNumberBook.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace BatmansSecretNumberBook.Services.PersonServices
{
    public class PersonService : IPersonServiceAsync
    {
        private readonly IRepositoryAsync<Person> _personRepository;

        public PersonService(IRepositoryAsync<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task CreatePersonAsync(Person person)
        {
            await _personRepository.AddAsync(person);
            await _personRepository.SaveChangesAsync();
        }

        public async Task DeletePersonAsync(int id)
        {
            var person = await _personRepository.GetAsync(id);
            _personRepository.Remove(person);
            await _personRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> ReadAllPersonsAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task<Person> ReadSinglePersonAsync(int id)
        {
            return await _personRepository.GetAsync(id);
        }

        public async Task UpdatePersonAsync(int id, Person newPerson)
        {
            var person = await _personRepository.GetAsync(1);
            person.Update(newPerson);
            await _personRepository.SaveChangesAsync();
        }
    }
}
