using Microsoft.EntityFrameworkCore;
using MoneyLake.Api.DataAccess.DTO;

namespace MoneyLake.Api.DataAccess
{
    public class DataContext: DbContext
    {
        public DbSet<GreenHouse> GreenHouses { get; set; }
        
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GreenHouse>().ToTable("GreenHouses");
            modelBuilder.Entity<GreenHouse>().HasKey(x => x.Id);
            modelBuilder.Entity<GreenHouse>().HasIndex(x => x.Id);
        }
    }
}
