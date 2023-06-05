using Microsoft.EntityFrameworkCore;
using GW.Api.Data.Models;
using GW.Api.Data.Repository.Shared;

namespace GW.Api.Data.Repository
{
    public class PlayListRepository : RepositoryBase<PlayListModel>
    {
        public PlayListRepository(DbContext dataContext)
            : base(dataContext) { }

        public override async Task<IEnumerable<PlayListModel>> GetAll()
        {
            return await Context
                .Set<PlayListModel>()
                .Include(p => p.Musics)!
                .ToListAsync();
        }

        public override async Task<PlayListModel?> GetById(int id) =>
            await Context
                .Set<PlayListModel>()
                .Include(p => p.Musics)!
                .FirstOrDefaultAsync(i => i.Id == id);
    }
}
