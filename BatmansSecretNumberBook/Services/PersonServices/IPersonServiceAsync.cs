namespace BatmansSecretNumberBook.Services.PersonServices
{
    public interface IPersonServiceAsync
    {
        Task CreatePersonAsync(Person person);
        Task<IEnumerable<Person>> ReadAllPersonsAsync();
        Task<Person> ReadSinglePersonAsync(int id);
        Task UpdatePersonAsync(int id, Person newPerson);
        Task DeletePersonAsync(int id);
    }
}