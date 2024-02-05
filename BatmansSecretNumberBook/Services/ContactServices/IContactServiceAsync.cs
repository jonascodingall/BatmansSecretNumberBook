namespace BatmansSecretNumberBook.Services.ContactServices
{
    public interface IContactServiceAsync
    {
        Task<Contact> CreateContactAsync(int personId, Contact contact);
        Task<List<Contact>> ReadAllContactAsync();
        Task<Contact> ReadSingleContactAsync(int id);
        Task<Contact> UpdateContactAsync(int id, Contact newContact);
        Task<Contact> DeleteContactAsync(int id);
    }
}
