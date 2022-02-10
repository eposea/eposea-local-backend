using AutoMapper;
using EposeaLocalBackend.Core.Interfaces.Managers;
using EposeaLocalBackend.Core.Interfaces.Repositories;
using EposeaLocalBackend.gRPC.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EposeaLocalBackend.Business.Managers
{
    public class CourseManager : ICourseManager
    {
        private readonly IRepository<Course> courseRepository;
        private readonly IMapper mapper;
        public CourseManager(ICourseRepository repository, IMapper mapper)
        {
            courseRepository = repository;
            this.mapper = mapper;
        }

        public async Task<CourseDto> AddAsync(Course entity)
        {
            var result = await courseRepository.AddAsync(entity);

            return mapper.Map<CourseDto>(result);
        }

        public IQueryable<CourseDto> GetCourses(GetCoursesRequest request)
        {
            return courseRepository.GetAll().Select(item => mapper.Map<CourseDto>(item));
        }

        public async Task<CourseDto> UpdateAsync(Course entity)
        {

            return null;
        }
    }
}
