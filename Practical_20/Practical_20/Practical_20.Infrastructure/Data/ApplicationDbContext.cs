using Microsoft.EntityFrameworkCore;
using Practical_20.Domain.Common;
using Practical_20.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_20.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach(var entry in entries)
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "System";
                }
                if(entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = "System";
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
