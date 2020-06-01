using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonalPage.Data.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task Delete(TEntity entity);
    }
}