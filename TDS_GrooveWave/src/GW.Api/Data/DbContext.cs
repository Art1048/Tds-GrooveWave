using Microsoft.EntityFrameworkCore;
using GW.Api.Data.Models;

namespace GW.Api.Data.Repository
{
    public class Context : DbContext
    {
        public DbSet<MusicModel>? MusicModel { get; set; }
        public DbSet<PlayListModel>? PlayListModel { get; set; }
        public DbSet<UserModel>? UserModel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseNpgsql("Host=localhost:5432;Database=meu_postgres;Username=postgres;Password=4Vfl4AtYdFMrxNq");
        // protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        //     options.UseSqlite("DataSource=tds.db;Cache=Shared");
    }
}
