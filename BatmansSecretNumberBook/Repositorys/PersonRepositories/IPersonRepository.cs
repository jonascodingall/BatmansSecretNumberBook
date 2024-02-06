namespace BatmansSecretNumberBook.Repositorys.PersonRepositories
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person? FirstOrDefault(Person person);
    }
}
