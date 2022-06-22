using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories.Entities;

public class StudentRepository : CrudRepository<Student>, IStudentRepository
{
    public StudentRepository(IObjectContext context) : base(context)
    {

    }
}