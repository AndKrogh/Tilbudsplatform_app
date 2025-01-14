using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.core.Entities;
using TilbudsPlatform.Entities;
using TilbudsPlatform.Model;

namespace TilbudsPlatform.core.Data
{
    public class TilbudsPlatformContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Worklog> Worklogs { get; set; }
        public DbSet<Estimate> Estimates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public TilbudsPlatformContext(DbContextOptions<TilbudsPlatformContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worklog>()
                .HasOne(w => w.WorkTask)
                .WithMany(t => t.Worklogs)
                .HasForeignKey(w => w.WorkTaskId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Worklog>()
                .HasOne(w => w.User)
                .WithMany(u => u.Worklogs)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkTask>()
                .HasOne(t => t.Project)
                .WithMany(p => p.WorkTasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
