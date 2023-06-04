using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Data.Models;
using Restaurant.Data.Data.Repository.Shared;

namespace Restaurant.Data.Data.Repository
{
    public class TableRepository : RepositoryBase<TableModel>
    {
        public TableRepository(DbContext dataContext)
            : base(dataContext) { }

        public override async Task<IEnumerable<TableModel>> GetAll()
        {
            return await Context
                .Set<TableModel>()
                .Include(p => p.Services)!
                .ThenInclude(p => p.ServiceLines)
                .ToListAsync();
        }

        public override async Task<TableModel?> GetById(int id) =>
            await Context
                .Set<TableModel>()
                .Include(p => p.Services)!
                .ThenInclude(p => p.ServiceLines)
                .FirstOrDefaultAsync(i => i.Id == id);
    }
}
