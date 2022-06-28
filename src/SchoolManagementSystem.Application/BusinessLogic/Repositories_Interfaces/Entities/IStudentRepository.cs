
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Repositories_Interfaces;

public interface IStudentRepository : IRepository<Student>
{
    /// Devuelve el estudiante con ese id
    /// En caso de no existir devuelve null
    Student GetById(string id);
}