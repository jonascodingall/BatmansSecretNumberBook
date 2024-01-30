using BatmansSecretNumberBook.DTOs;
using BatmansSecretNumberBook.Wrapper;

namespace BatmansSecretNumberBook.Services.ContactServices
{
    public interface IContactServiceAsync
    {
        Task<ResponseWrapper<ContactDto>> CreateContactAsync(ContactDto person);
        Task<ResponseWrapper<List<ContactDto>>> ReadAllContactAsync();
        Task<ResponseWrapper<ContactDto>> ReadSingleContactAsync(int id);
        Task<ResponseWrapper<ContactDto>> UpdateContactAsync(int id, ContactDto request);
        Task<ResponseWrapper<ContactDto>> DeleteContactAsync(int id);
    }
}
