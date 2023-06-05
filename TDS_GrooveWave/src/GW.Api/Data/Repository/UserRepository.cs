using Microsoft.EntityFrameworkCore;
using GW.Api.Data.Models;
using GW.Api.Data.Repository.Shared;

namespace GW.Api.Data.Repository
{
    public class UserRepository : RepositoryBase<UserModel>
    {
        public UserRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
