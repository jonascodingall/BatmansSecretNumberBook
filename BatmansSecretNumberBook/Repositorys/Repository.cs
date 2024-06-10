using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BatmansSecretNumberBook.Repositorys
{
    public class Repository<TDbContext, TEntity> : IRepository<TEntity> 
        where TDbContext : DbContext
        where TEntity : class
    {
        protected readonly TDbContext _context;
        public Repository(TDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity?> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }


        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
