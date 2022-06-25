
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Application.Repositories_Interfaces;
// using SchoolManagementSystem.Infrastructure.Persistence;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class ClassroomRepository : CrudRepository<Classroom>, IClassroomRepository
{
    public ClassroomRepository(IObjectContext context) : base(context)
    {

    }
}
