using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Application.Repositories_Interfaces;

namespace SchoolManagementSystem.Infrastructure.Repositories.Entities;

public class TeacherRepository : CrudRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(IObjectContext context) : base(context)
    {

    }
}