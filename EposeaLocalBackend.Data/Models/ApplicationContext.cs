using EposeaLocalBackend.gRPC.Course;
using Microsoft.EntityFrameworkCore;

namespace EposeaLocalBackend.Data.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<Item> Item { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
