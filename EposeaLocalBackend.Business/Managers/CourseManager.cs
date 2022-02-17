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


        public async Task<Course> CreateCourseAsync(Course course)
        {
            var result = await courseRepository.AddAsync(course);

            return result;
        }

        public Course GetCourse(CourseFilter filter)
        {
            var courses = courseRepository.GetAll();
            return courses.FirstOrDefault(course => course.Id == filter.Id);
        }


        public async Task DeleteCourseAsync(CourseFilter filter)
        {
            var courseToDelete = GetCourse(filter);

            await courseRepository.DeleteAsync(courseToDelete);
        }


        public async Task<Course> UpdateCourseAsync(Course course)
        {
            var result = await courseRepository.UpdateAsync(course);

            return result;
        }
    }
}
