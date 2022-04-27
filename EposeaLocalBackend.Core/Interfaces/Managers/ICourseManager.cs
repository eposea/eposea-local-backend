using EposeaLocalBackend.Core.Interfaces.Infrastructure;
using EposeaLocalBackend.gRPC.Proto.Course;
using System.Threading.Tasks;

namespace EposeaLocalBackend.Core.Interfaces.Managers
{
    public interface ICourseManager : ITransientService
    {
        public Course GetCourse(GetCourseRequest request);

    }
}
