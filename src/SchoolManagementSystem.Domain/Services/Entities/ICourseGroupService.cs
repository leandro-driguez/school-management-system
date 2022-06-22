using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Domain.Services;

public interface ICourseGroupService : IService<CourseGroup>
{
    // Selecciona un CourseGroup con cierto id
    // y toma toda su información
    CourseGroup GetCourseGroupById(string id);
}