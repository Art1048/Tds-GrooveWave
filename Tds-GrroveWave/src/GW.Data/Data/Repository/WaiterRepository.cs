using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Data.Models;
using Restaurant.Data.Data.Repository.Shared;

namespace Restaurant.Data.Data.Repository
{
    public class WaiterRepository : RepositoryBase<WaiterModel>
    {
        public WaiterRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
