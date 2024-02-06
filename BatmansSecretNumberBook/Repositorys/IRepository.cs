using System.Linq.Expressions;

namespace BatmansSecretNumberBook.Repositorys
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity?> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
