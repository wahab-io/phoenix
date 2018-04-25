using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Phoenix.Core
{
    public interface IRepository<TEntity>
    {
         Task<IQueryable<TEntity>> GetAll();
         Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
         Task<TEntity> GetById(long id);
         Task Create(TEntity newEntity);
         Task Remove(TEntity entity);

    }
}