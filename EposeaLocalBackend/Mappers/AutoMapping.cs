using AutoMapper;
using EposeaLocalBackend.Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EposeaLocalBackend.Core.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Course, GetCourseResponce>
        }
    }
}
