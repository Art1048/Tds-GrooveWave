using Microsoft.EntityFrameworkCore;
using GW.Api.Data.Models;
using GW.Api.Data.Repository.Shared;

namespace GW.Api.Data.Repository
{
    public class MusicRepository : RepositoryBase<MusicModel>
    {
        public MusicRepository(DbContext dataContext)
            : base(dataContext) { }

        public override async Task<IEnumerable<MusicModel>> GetAll()
        {
            return await Context
                .Set<MusicModel>()
                .ToListAsync();
        }

        public override async Task<MusicModel?> GetById(int id) =>
            await Context
                .Set<MusicModel>()
                .FirstOrDefaultAsync(i => i.Id == id);
    }
}
