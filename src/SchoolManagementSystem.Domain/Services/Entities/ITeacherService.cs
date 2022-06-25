using SchoolManagementSystem.Domain.Entities;


namespace SchoolManagementSystem.Domain.Services;

public interface ITeacherService : IService<Teacher>
{
    // Selecciona a un profesor con cierto id
    // y toma toda su informaci�n
    Teacher GetTeacherById(string id);
    public bool SpecialPost(string id);
}