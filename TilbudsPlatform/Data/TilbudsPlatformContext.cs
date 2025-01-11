using Microsoft.EntityFrameworkCore;
using TilbudsPlatform.Entities;
using TilbudsPlatform.Model;

namespace TilbudsPlatform.Data
{
    public class TilbudsPlatformContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Worklog> Worklogs { get; set; }
        public DbSet<Estimate> Estimates { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkTask> Tasks { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        public TilbudsPlatformContext(DbContextOptions<TilbudsPlatformContext> options)
            : base(options)
        {
        }

    }
}
