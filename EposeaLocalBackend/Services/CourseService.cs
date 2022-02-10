using EposeaLocalBackend.Data.Models;
using Grpc.Core;
using System.Linq;
using System.Threading.Tasks;

namespace EposeaLocalBackend
{
    public class CourseService : Courser.CourserBase
    {
        private readonly ApplicationContext applicationContext;
        public CourseService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }
        public override Task GetCourse(GetCourseRequest request, IServerStreamWriter<GetCourseResponce> responseStream, ServerCallContext context)
        {
            var result = applicationContext.Course.Where(item => item.Id == request.Id);
            return Task.FromResult(result);
        }
    }
}
