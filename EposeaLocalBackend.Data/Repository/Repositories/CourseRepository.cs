using EposeaLocalBackend.Core.Interfaces.Repositories;
using EposeaLocalBackend.Data.Models;
using EposeaLocalBackend.gRPC.Proto.Course;
using Microsoft.Extensions.Logging;

namespace EposeaLocalBackend.Data.Repository.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationContext applicationContext, ILogger<CourseRepository> logger) : base(applicationContext, logger)
        {
        }
    }
}
