using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Data.Models;
using Restaurant.Data.Data.Repository.Shared;

namespace Restaurant.Data.Data.Repository
{
    public class ServiceRepository : RepositoryBase<ServiceModel>
    {
        public ServiceRepository(DbContext dataContext)
            : base(dataContext) { }

        public override async Task<IEnumerable<ServiceModel>> GetAll()
        {
            return await Context
                .Set<ServiceModel>()
                .Include(p => p.ServiceLines)!
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p!.Category)
                .Include(p => p.Table)
                .ToListAsync();
        }

        public override async Task<ServiceModel?> GetById(int id) =>
            await Context
                .Set<ServiceModel>()
                .Include(p => p.ServiceLines)!
                .ThenInclude(p => p.Product)
                .ThenInclude(p => p!.Category)
                .Include(p => p.Table)
                .FirstOrDefaultAsync(i => i.Id == id);
    }
}
