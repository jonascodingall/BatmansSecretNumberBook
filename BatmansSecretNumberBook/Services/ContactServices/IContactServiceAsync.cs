using BatmansSecretNumberBook.DTOs;
using BatmansSecretNumberBook.Wrapper;

namespace BatmansSecretNumberBook.Services.ContactServices
{
    public interface IContactServiceAsync
    {
        Task<ResponseWrapper<Contact>> CreateContactAsync(int personId, ContactDto contact);
        Task<ResponseWrapper<List<Contact>>> ReadAllContactAsync();
        Task<ResponseWrapper<Contact>> ReadSingleContactAsync(int id);
        Task<ResponseWrapper<Contact>> UpdateContactAsync(int id, ContactDto request);
        Task<ResponseWrapper<Contact>> DeleteContactAsync(int id);
    }
}
