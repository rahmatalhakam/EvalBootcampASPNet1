using System;
using AutoMapper;
using EvalBootcampASPNet1.Dtos;
using EvalBootcampASPNet1.Models;

namespace EvalBootcampASPNet1.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseGDto>();
            CreateMap<CourseCUDto, Course>();
        }
    }
}
