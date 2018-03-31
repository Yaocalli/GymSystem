using Maintenance.Domain;
using System.Data.Entity;

namespace Maintenance.Data
{
    public class MaintenanceContext : DbContext
    {
        public MaintenanceContext() 
            :base("Yaocalli.GymSystem")
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Maintenance");

            base.OnModelCreating(modelBuilder);
        }
    }
}
