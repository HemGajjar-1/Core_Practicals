using Microsoft.EntityFrameworkCore;
using Practical_17.Models.Entity;

namespace Practical_17.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
    
        }
        public DbSet<Student> Students { get; set; } 
        public DbSet<User> Users{ get; set; } 
        public DbSet<Role> Roles{ get; set; } 
    }
}
