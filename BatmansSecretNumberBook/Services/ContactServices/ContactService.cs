
using BatmansSecretNumberBook.Data;
using BatmansSecretNumberBook.Exeptions;
using BatmansSecretNumberBook.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BatmansSecretNumberBook.Services.ContactServices
{
    public class ContactService : IContactServiceAsync
    {
        private readonly DatabaseContext _context;
        public ContactService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Contact> CreateContactAsync(int personId, Contact contact)
        {
            contact.PersonId = _context.Contacts.Find(personId)?.PersonId ?? throw new PersonNotFoundExeption();
            _context.Add(contact);
            await _context.SaveChangesAsync();
            return _context.Contacts.FirstOrDefault(contact);
        }

        public async Task<List<Contact>> ReadAllContactAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> ReadSingleContactAsync(int id)
        {
            return await _context.Contacts.FindAsync(id) ?? throw new ContactNotFoundExeption();
        }

        public async Task<Contact> UpdateContactAsync(int id, Contact newContact)
        {
            var contact = await _context.Contacts.FindAsync(id) ?? throw new ContactNotFoundExeption();
            contact.Update(newContact);
            return newContact;
            
        }
        public async Task<Contact> DeleteContactAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id) ?? throw new ContactNotFoundExeption();
            _context.Remove(contact);
            return contact;
        }
    }
}
