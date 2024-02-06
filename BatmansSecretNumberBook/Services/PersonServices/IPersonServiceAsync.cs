namespace BatmansSecretNumberBook.Services.PersonServices
{
    public interface IPersonServiceAsync : IPersonService
    {
        Task<Person> CreatePersonAsync(Person person);
        Task<List<Person>> ReadAllPersonsAsync();
        Task<Person> ReadSinglePersonAsync(int id);
        Task<Person> UpdatePersonAsync(int id, Person newPerson);
        Task<Person> DeletePersonAsync(int id);
    }
}
