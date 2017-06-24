using Microsoft.EntityFrameworkCore;
using MoneyLake.Api.DataAccess.DTO;

namespace MoneyLake.Api.DataAccess
{
    public class DataContext: DbContext
    {
        private string ConnectionString{ get; set; }

        public DataContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public DbSet<GreenHouse> GreenHouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(ConnectionString);
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GreenHouse>().ToTable("GreenHouses");
            modelBuilder.Entity<GreenHouse>().HasKey(x => x.Id);
            modelBuilder.Entity<GreenHouse>().HasIndex(x => x.Id);            
        }
    }
}
