using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PRSCapstoneWebPractice.Models;

namespace PRSCapstoneWebPractice.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext (DbContextOptions<TestDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder model) {
            model.Entity<User>(e => {
                e.HasKey(x => x.Id);
                e.Property(x => x.Username).HasMaxLength(30).IsRequired();
                e.Property(x => x.Password).HasMaxLength(30).IsRequired();
                e.Property(x => x.Firstname).HasMaxLength(30).IsRequired();
                e.Property(x => x.Lastname).HasMaxLength(30).IsRequired();
                e.Property(x => x.Phone).HasMaxLength(12);
                e.Property(x => x.Email).HasMaxLength(5);
                e.Property(x => x.IsReviewer).IsRequired().HasDefaultValue(0);
                e.Property(x => x.IsAdmin).IsRequired().HasDefaultValue(0);
                e.HasIndex(x => x.Username).IsUnique();
            });
        }

        public DbSet<PRSCapstoneWebPractice.Models.User> User { get; set; }
    }
}
