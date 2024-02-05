
using BatmansSecretNumberBook.Data;
using BatmansSecretNumberBook.Exeptions;
using BatmansSecretNumberBook.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BatmansSecretNumberBook.Services.ContactServices
{
    public class ContactService : IContactServiceAsync
    {
        private readonly DataContext _context;
        public ContactService(DataContext context)
        {
            _context = context;
        }

        public async Task<Contact> CreateContactAsync(int personId, Contact contact)
        {
            contact.PersonId = _context.Personen.Find(personId)?.Id ?? throw new PersonNotFoundException();
            _context.Add(contact);
            await _context.SaveChangesAsync();
            return _context.Contacts.Find(contact.Id) ?? throw new ContactNotFoundException();
        }

        public async Task<List<Contact>> ReadAllContactAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> ReadSingleContactAsync(int id)
        {
            return await _context.Contacts.FindAsync(id) ?? throw new ContactNotFoundException();
        }

        public async Task<Contact> UpdateContactAsync(int id, Contact newContact)
        {
            var contact = await _context.Contacts.FindAsync(id) ?? throw new ContactNotFoundException();
            contact.UpdateContact(newContact);
            await _context.SaveChangesAsync();
            return await _context.Contacts.FindAsync(id) ?? throw new ContactNotFoundException();
        }

        public async Task<Contact> DeleteContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id) ?? throw new ContactNotFoundException();
            _context.Remove(contact);
            await _context.SaveChangesAsync();
            return contact;
        }
    }
}
