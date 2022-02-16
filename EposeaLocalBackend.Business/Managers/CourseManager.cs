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
        private readonly IMapper mapper;
        public CourseManager(ICourseRepository courseRepository, IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }

        public async Task<Course> AddAsync(Course entity)
        {
            var result = await courseRepository.AddAsync(entity);

            return result;
        }

        public Course GetCourse(GetCourseRequest request)
        {
            return courseRepository.GetAll().FirstOrDefault(item => item.Id == request.Id);
        }

        public Course Update(Course entity)
        {
            return null;
        }
    }
}
