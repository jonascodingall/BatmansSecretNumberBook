using BatmansSecretNumberBook.DTOs;
using BatmansSecretNumberBook.Wrapper;

namespace BatmansSecretNumberBook.Services.ContactServices
{
    public class ContactService : IContactServiceAsync
    {
        public Task<ResponseWrapper<ContactDto>> CreateContactAsync(ContactDto person)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseWrapper<ContactDto>> DeleteContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseWrapper<List<ContactDto>>> ReadAllContactAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseWrapper<ContactDto>> ReadSingleContactAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseWrapper<ContactDto>> UpdateContactAsync(int id, ContactDto request)
        {
            throw new NotImplementedException();
        }
    }
}
