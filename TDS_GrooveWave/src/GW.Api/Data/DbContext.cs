using Microsoft.EntityFrameworkCore;
using GW.Api.Data.Models;

namespace GW.Api.Data.Repository
{
    public class Context : DbContext
    {
        public DbSet<MusicModel>? ServiceModel { get; set; }
        public DbSet<PlayListModel>? TableModel { get; set; }
        public DbSet<UserModel>? UserModel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseNpgsql("Host=localhost:5432;Username=arthu;Password=123;Database=postgres");
    }
}
