using Microsoft.EntityFrameworkCore;
using GW.Api.Data.Models;

namespace GW.Api.Data.Repository
{
    public class Context : DbContext
    {
        public DbSet<MusicModel>? MusicModel { get; set; }
        public DbSet<PlayListModel>? PlayListModel { get; set; }
        public DbSet<UserModel>? UserModel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) 

        //PostgresLocal
        =>
            options.UseNpgsql("Host=localhost:5432;Database=meu_postgres;Username=Art;Password=4Vfl4AtYdFMrxNq");


        // Postgres docker
        // {
        //     string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

        //     if (string.IsNullOrEmpty(connectionString))
        //     {
        //         throw new InvalidOperationException("A connection string must be provided.");
        //     }

        //     options.UseNpgsql(connectionString);
        // }


        

        //SQLLite
        // protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        //     options.UseSqlite("DataSource=tds.db;Cache=Shared");
    }
}
