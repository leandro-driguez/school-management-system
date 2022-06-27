
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Repositories_Interfaces;

public interface ICourseGroupRepository : IRepository<CourseGroup>
{
    CourseGroup GetById(string id);
}