using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Domain.Services;

public interface ITeacherService : IService<Teacher>
{
    // Selecciona a un profesor con cierto id
    // y toma toda su información
    Teacher GetTeacherById(string id);
}