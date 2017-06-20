using Microsoft.EntityFrameworkCore;
using MoneyLake.Api.DataAccess.DTO;

namespace MoneyLake.Api.DataAccess
{
    public class DataContext: DbContext
    {
        public DbSet<GreenHouse> GreenHouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connectionString = "Host=fizzy-cherry.db.elephantsql.com;Database=tbqctuyo;Username=tbqctuyo;Password=bsaJa6_79RsMcdghTQ3PS3DZsymEpCdx";
            builder.UseNpgsql(connectionString);
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
