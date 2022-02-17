using EposeaLocalBackend.Core.Interfaces.Infrastructure;
using EposeaLocalBackend.gRPC.Proto.Course;
using System.Linq;
using System.Threading.Tasks;

namespace EposeaLocalBackend.Core.Interfaces.Managers
{
    public interface ICourseManager : ITransientService
    {

        public Task<Course> CreateCourseAsync(Course item);
        public Course GetCourse(CourseFilter filter);
        public Task<Course> UpdateCourseAsync(Course item);
        public Task DeleteCourseAsync(CourseFilter filter);

    }
}
