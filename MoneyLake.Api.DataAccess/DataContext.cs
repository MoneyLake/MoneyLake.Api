using Microsoft.EntityFrameworkCore;
using MoneyLake.Api.DataAccess.DTO;

namespace MoneyLake.Api.DataAccess
{
    public class DataContext: DbContext
    {
        public DbSet<GreenHouse> GreenHouses { get; set; }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<OperationStatus> OperationStatuses { get; set; }
        
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<GreenHouse>()
                .ToTable("GreenHouses")
                .HasKey(x => x.Id);
            
            modelBuilder
                .Entity<GreenHouse>()
                .HasIndex(x => x.Id);
            
            modelBuilder
                .Entity<User>()
                .ToTable("Users")
                .HasKey(x => x.Login);
            
            modelBuilder
                .Entity<User>()
                .HasIndex(x => x.Login);
            
            modelBuilder
                .Entity<Role>()
                .ToTable("Roles")
                .HasKey(x => x.Id);
            
            modelBuilder
                .Entity<Role>()
                .HasIndex(x => x.Id);
            
            modelBuilder
                .Entity<Role>()
                .HasMany(x => x.Users)
                .WithOne(x => x.Role)
                .IsRequired();
            
            modelBuilder
                .Entity<Operation>()
                .ToTable("Operations")
                .HasKey(x => x.Id);
            
            modelBuilder
                .Entity<Operation>()
                .HasIndex(x => x.Id);
            
            modelBuilder
                .Entity<User>()
                .HasMany(x => x.Operations)
                .WithOne(x => x.User)
                .IsRequired();
            
            modelBuilder
                .Entity<OperationStatus>()
                .ToTable("OperationStatuses")
                .HasKey(x => x.Id);
            
            modelBuilder
                .Entity<OperationStatus>()
                .HasIndex(x => x.Id);
        }
    }
}
