using BatmansSecretNumberBook.Repositorys.ContactRepositories;
using BatmansSecretNumberBook.Repositorys.PersonRepositories;

namespace BatmansSecretNumberBook.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository Persons { get; }
        IContactRepository Contacts { get; }
        int Complete();
    }
}
