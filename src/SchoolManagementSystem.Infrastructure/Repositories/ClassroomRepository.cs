
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Interfaces;
// using SchoolManagementSystem.Infrastructure.Data;

namespace SchoolManagementSystem.Infrastructure.Repositories;

public class ClassroomRepository : CrudRepository<Classroom>
{
    public ClassroomRepository(IObjectContext context) : base(context)
    {

    }
}
