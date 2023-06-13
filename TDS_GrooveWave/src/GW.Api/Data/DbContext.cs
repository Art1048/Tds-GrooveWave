using Microsoft.EntityFrameworkCore;
using GW.Api.Data.Models;

namespace GW.Api.Data.Repository
{
    public class Context : DbContext
    {
        public DbSet<MusicModel>? MusicModel { get; set; }
        public DbSet<PlayListModel>? PlayListModel { get; set; }
        public DbSet<UserModel>? UserModel { get; set; }
        // protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        //     options.UseNpgsql("Host=localhost:5432;Username=postgres;Password=senha_secreta;Database=meu_postgres");
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite("DataSource=tds.db;Cache=Shared");
    }
}
