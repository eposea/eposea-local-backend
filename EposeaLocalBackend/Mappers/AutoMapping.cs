using AutoMapper;
using EposeaLocalBackend.gRPC.Course;

namespace EposeaLocalBackend.API.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Course, CourseDto>();
        }
    }
}
