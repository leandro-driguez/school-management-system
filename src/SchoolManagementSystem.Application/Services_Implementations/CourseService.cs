
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class CourseService : BaseService<Course>, ICourseService
{
    public CourseService(ICourseRepository repository) : base(repository)
    {

    }

    public Course GetCourseById(string id)
    {
        return Query()
            .Where(course => course.Id == id)
            .Include(course => course.TeacherCourseRelations)            
            .Include(course => course.CourseGroups)
            .FirstOrDefault();
    }
}