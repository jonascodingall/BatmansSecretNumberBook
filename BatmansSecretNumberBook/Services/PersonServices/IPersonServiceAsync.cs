using BatmansSecretNumberBook.DTOs;
using BatmansSecretNumberBook.Wrapper;

namespace BatmansSecretNumberBook.Services.PersonServices
{
    public interface IPersonServiceAsync
    {
        Task<ResponseWrapper<PersonDto>> CreatePersonAsync(PersonDto person);
        Task<ResponseWrapper<List<PersonDto>>> ReadAllPersonsAsync();
        Task<ResponseWrapper<PersonDto>> ReadSinglePersonAsync(int id);
        Task<ResponseWrapper<PersonDto>> UpdatePersonAsync(int id, PersonDto request);
        Task<ResponseWrapper<PersonDto>> DeletePersonAsync(int id);
    }
}
