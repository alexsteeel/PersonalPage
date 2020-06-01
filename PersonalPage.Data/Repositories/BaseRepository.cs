using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PersonalPage.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;

        public BaseRepository(ApplicationDbContext appContext)
        {
            this.Context = appContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public ValueTask<TEntity> GetByIdAsync(int id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => Context.Set<TEntity>().Update(entity));
            await Context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }
    }
}