using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Data.Models.Shared;

namespace Restaurant.Data.Data.Repository.Shared
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : Entity
    {
        protected readonly DbContext Context;

        protected RepositoryBase(DbContext dataContext) => Context = dataContext;

        public virtual async Task<IEnumerable<TEntity>> GetAll() =>
            await Context.Set<TEntity>().AsNoTracking().ToListAsync();

        public virtual async Task<TEntity?> GetById(int id) =>
            await Context.Set<TEntity>().FindAsync(id);

        public virtual async Task<object> Add(TEntity entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return entity.Id;
        }

        public virtual async Task Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
        }

        public virtual async Task Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task RemoveById(int id)
        {
            var entity =
                await GetById(id) ?? throw new Exception("O registro não existe na base de dados.");
            await Remove(entity);
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
