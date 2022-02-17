using EposeaLocalBackend.Core.Interfaces.Managers;
using EposeaLocalBackend.gRPC.Proto.Course;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Threading.Tasks;

namespace EposeaLocalBackend
{
    public class CourseService : gRPC.Proto.Course.CourseService.CourseServiceBase
    {
        private readonly ICourseManager courseManager;
        public CourseService(ICourseManager courseManager)
        {
            this.courseManager = courseManager;
        }
        public override Task<Course> CreateCourse(Course request, ServerCallContext context)
        {
            return courseManager.CreateCourseAsync(request);
        }
        public override Task<Course> GetCourse(CourseFilter request, ServerCallContext context)
        {
            return Task.FromResult(courseManager.GetCourse(request));
        }
        public override async Task<Course> UpdateCourse(Course request, ServerCallContext context)
        {
            return await courseManager.UpdateCourseAsync(request);
        }
        public override async Task<Empty> RemoveCourse(CourseFilter request, ServerCallContext context)
        {
            await courseManager.DeleteCourseAsync(request);

            return new Empty();
        }
    }
}
