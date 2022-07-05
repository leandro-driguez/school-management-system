
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class CourseGroupService : ActiveService<CourseGroup>, ICourseGroupService
{
    public CourseGroupService(ICourseGroupRepository repository) : base(repository)
    {

    }

    public CourseGroup GetCourseGroupById(string id)
    {
        return Query()
            .Where(courseGroup => courseGroup.Id == id) 
            .Include(courseGroup => courseGroup.Course)
            .Include(courseGroup => courseGroup.StudentCourseGroupRelations)            
            .FirstOrDefault();
    }
}