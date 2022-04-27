using EposeaLocalBackend.Core.Interfaces.Infrastructure;
using EposeaLocalBackend.gRPC.Proto.Course;

namespace EposeaLocalBackend.Core.Interfaces.Repositories
{
    public interface ICourseRepository : ITransientService, IRepository<Course>
    {
    }
}
