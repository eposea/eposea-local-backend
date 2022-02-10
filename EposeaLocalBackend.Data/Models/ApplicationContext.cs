using EposeaLocalBackend.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace EposeaLocalBackend.Data.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Item> Items { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
