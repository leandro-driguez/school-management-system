
using AutoMapper;
using SchoolManagementSystem.API.Dtos;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.API.Mappers;

public class CourseGroupProfile : Profile
{
    public CourseGroupProfile()
    {
        CreateMap<CourseGroup, CourseCourseGroupRelationDto>();
        CreateMap<CourseCourseGroupRelationDto, CourseGroup>();
        CreateMap<CourseGroup, CourseGroupDto>();
        CreateMap<CourseGroupDto, CourseGroup>();
    }
}