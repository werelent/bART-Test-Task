using Microsoft.EntityFrameworkCore;

namespace bART_Test_Task.Models
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Contacts)
                .WithOne(c => c.Account)
                .HasForeignKey(c => c.AccountID);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Incident)
                .WithMany(a => a.Accounts)
                .HasForeignKey(a => a.IncidentName);
        }
    }
}
