using Marks.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Marks.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<People> Peoples { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                .HasIndex("FirstName", "LastName")
                .IsUnique();
        }
    }
}
