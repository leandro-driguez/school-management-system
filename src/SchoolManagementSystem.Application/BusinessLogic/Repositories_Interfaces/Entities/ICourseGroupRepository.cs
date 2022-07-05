
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Repositories_Interfaces;

public interface ICourseGroupRepository : IActiveRepository<CourseGroup>
{
    CourseGroup GetById(string id);
}