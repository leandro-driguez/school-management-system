using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class CourseGroupRepository : CrudRepository<CourseGroup>, ICourseGroupRepository
{
    public CourseGroupRepository(IObjectContext context) : base(context)
    {

    }
}