using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Domain.Services;

public interface IStudentService : IService<Student>
{
    // Selecciona a un estudiante con cierto id
    // y toma toda su información
    Student GetStudentById(string id);
}