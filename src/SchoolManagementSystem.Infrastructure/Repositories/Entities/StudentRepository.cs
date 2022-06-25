using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Persistence;
using SchoolManagementSystem.Application.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class StudentRepository : CrudRepository<Student>, IStudentRepository
{
    public StudentRepository(IObjectContext context) : base(context)
    {

    }
}