using Maintenance.Domain;
using System.Data.Entity;

namespace Maintenance.Data
{
    public class MaintenanceContext : DbContext
    {
        public MaintenanceContext() 
            :base("Yaocalli_SystemGymDb")
        {
            
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Maintenance");

            modelBuilder.Entity<Member>()
                .HasOptional(c => c.ContactDetail)
                .WithRequired(d => d.Member);

            modelBuilder.Entity<Member>()
                .HasOptional(c => c.Address)
                .WithRequired(d => d.Member);

            base.OnModelCreating(modelBuilder);
        }
    }
}
