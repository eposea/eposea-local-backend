using EposeaLocalBackend.Core.Interfaces.Infrastructure;
using EposeaLocalBackend.gRPC.Course;
using System.Linq;

namespace EposeaLocalBackend.Core.Interfaces.Managers
{
    public interface ICourseManager : ITransientService
    {

        public IQueryable<CourseDto> GetCourses(GetCoursesRequest request);

    }
}
