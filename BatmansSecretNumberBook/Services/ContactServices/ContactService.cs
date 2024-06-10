
using BatmansSecretNumberBook.Data;
using BatmansSecretNumberBook.Exeptions;
using BatmansSecretNumberBook.Mappers;
using BatmansSecretNumberBook.Models.PersonModels;
using BatmansSecretNumberBook.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BatmansSecretNumberBook.Services.ContactServices
{
    public class ContactService : IContactServiceAsync
    {
        private readonly IRepositoryAsync<Contact> _contactRepository;
        public ContactService(IRepositoryAsync<Contact> personRepository)
        {
            _contactRepository = personRepository;
        }

        public async Task CreateContactAsync(Contact contact)
        {
            await _contactRepository.AddAsync(contact);
            await _contactRepository.SaveChangesAsync();
        }

        public async Task DeleteContactAsync(int id)
        {
            var contact = await _contactRepository.GetAsync(id);
            _contactRepository.Remove(contact);
            await _contactRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contact>> ReadAllContactAsync()
        {
            return await _contactRepository.GetAllAsync();
        }

        public async Task<Contact> ReadSingleContactAsync(int id)
        {
            return await _contactRepository.GetAsync(id);
        }

        public async Task UpdateContactAsync(int id, Contact newContact)
        {
            var contact = await _contactRepository.GetAsync(1);
            contact.UpdateContact(newContact);
            await _contactRepository.SaveChangesAsync();
        }
    }
}
