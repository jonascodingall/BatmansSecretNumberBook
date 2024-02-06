namespace BatmansSecretNumberBook.Services.PersonServices
{
    public interface IPersonService
    {
        Person CreatePerson(Person person);
        List<Person> ReadAllPersons();
        Person ReadSinglePerson(int id);
        Person UpdatePerson(int id, Person newPerson);
        Person DeletePerson(int id);
    }
}
