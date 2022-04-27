using AutoMapper;
using EposeaLocalBackend.Core.Interfaces.Managers;
using EposeaLocalBackend.Core.Interfaces.Repositories;
using EposeaLocalBackend.gRPC.Proto.Course;
using System.Linq;
using System.Threading.Tasks;

namespace EposeaLocalBackend.Business.Managers
{
    public class CourseManager : ICourseManager
    {
        private readonly ICourseRepository courseRepository;
        public CourseManager(ICourseRepository courseRepository, IMapper mapper)
        {
            this.courseRepository = courseRepository;
        }
        public Course GetCourse(GetCourseRequest request)
        {
            var courses = courseRepository.GetAll();
            return courses.FirstOrDefault(course => course.Id == request.Id);
        }
    }
}
