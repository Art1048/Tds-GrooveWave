using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Data.Models;
using Restaurant.Data.Data.Repository.Shared;

namespace Restaurant.Data.Data.Repository
{
    public class ServiceLineRepository : RepositoryBase<ServiceLineModel>
    {
        public ServiceLineRepository(DbContext dataContext)
            : base(dataContext) { }

        public override async Task<IEnumerable<ServiceLineModel>> GetAll()
        {
            return await Context.Set<ServiceLineModel>().Include(p => p.Product)!.ToListAsync();
        }

        public override async Task<ServiceLineModel?> GetById(int id) =>
            await Context
                .Set<ServiceLineModel>()
                .Include(p => p.Product)!
                .FirstOrDefaultAsync(i => i.Id == id);
    }
}
