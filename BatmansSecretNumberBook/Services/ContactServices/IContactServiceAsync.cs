namespace BatmansSecretNumberBook.Services.ContactServices
{
    public interface IContactServiceAsync
    {
        Task CreateContactAsync(Contact contact);
        Task<IEnumerable<Contact>> ReadAllContactAsync();
        Task<Contact> ReadSingleContactAsync(int id);
        Task UpdateContactAsync(int id, Contact newContact);
        Task DeleteContactAsync(int id);
    }
}
