using Restaurant.Data.Data.Models.Shared;

namespace Restaurant.Data.Data.Repository.Shared
{
    public interface IRepositoryBase<TEntity> : IDisposable
        where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        Task<object> Add(TEntity objeto);
        Task Update(TEntity objeto);
        Task Remove(TEntity objeto);
        Task RemoveById(int id);
    }
}
