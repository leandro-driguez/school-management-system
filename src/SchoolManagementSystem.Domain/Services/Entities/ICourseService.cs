using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Domain.Services.Entities;

public interface ICourseService : IService<Course>
{
    // Selecciona un curso con cierto id
    // y toma toda su información
    Course GetCourseById(string id);
}