
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces.Entities;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Services;

namespace SchoolManagementSystem.Application.Services_Implementations.Entities;

public class StudentService : BaseService<Student>, IStudentService
{
    public StudentService(IStudentRepository repository) : base(repository)
    {

    }

    public Student GetStudentById(string id)
    {
        return Query()
            .Where(student => student.Id == id) 
            .Include(student => student.StudentCourseGroupRelations)
            .FirstOrDefault();
    }

    public override IQueryable<Student> Query()
    {
        return base.Query()
            .Include(student => student.Tuitor);
    }
}