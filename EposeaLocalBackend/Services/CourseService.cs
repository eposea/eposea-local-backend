using EposeaLocalBackend.Core.Interfaces.Managers;
using EposeaLocalBackend.Data.Models;
using EposeaLocalBackend.gRPC.Course;
using Grpc.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EposeaLocalBackend
{
    public class CourseService : Courser.CourserBase
    {
        private readonly ICourseManager courseManager;
        public CourseService(ICourseManager courseManager)
        {
            this.courseManager = courseManager;
        }

        public override async Task GetCourses(GetCoursesRequest request, IServerStreamWriter<CourseDto> responseStream, ServerCallContext context)
        {
            var result = courseManager.GetCourses(request).GetEnumerator();
            while (!context.CancellationToken.IsCancellationRequested && result.MoveNext())
            {
                await responseStream.WriteAsync(result.Current);
                await Task.Delay(TimeSpan.FromSeconds(1), context.CancellationToken);
            }
        }
    }
}
