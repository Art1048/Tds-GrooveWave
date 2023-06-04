using Microsoft.EntityFrameworkCore;
using Restaurant.Data.Data.Models;
using Restaurant.Data.Data.Repository.Shared;

namespace Restaurant.Data.Data.Repository
{
    public class ProductRepository : RepositoryBase<ProductModel>
    {
        public ProductRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
