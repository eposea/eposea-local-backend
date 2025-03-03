﻿using EposeaLocalBackend.Core.Interfaces.Managers;
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

        public override Task<Course> GetCourse(GetCourseRequest request, ServerCallContext context)
        {
            return Task.FromResult(courseManager.GetCourse(request));
        }
    }
}
