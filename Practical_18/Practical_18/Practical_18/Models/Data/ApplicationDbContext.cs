using Microsoft.EntityFrameworkCore;
using Practical_18.Models.Entity;
namespace Practical_18.Models.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
