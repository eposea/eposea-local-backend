using EposeaLocalBackend.gRPC.Proto.Course;
using EposeaLocalBackend.gRPC.Proto.Item;
using EposeaLocalBackend.gRPC.Proto.Section;
using Microsoft.EntityFrameworkCore;

namespace EposeaLocalBackend.Data.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Item> Item { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql().UseSnakeCaseNamingConvention();
            base.OnConfiguring(optionsBuilder);
        }

    }
}
