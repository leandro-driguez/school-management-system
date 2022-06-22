
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Application.Repositories_Interfaces.Entities;
// using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories.Entities;

public class ClassroomRepository : CrudRepository<Classroom>, IClassroomRepository
{
    public ClassroomRepository(IObjectContext context) : base(context)
    {

    }
}
