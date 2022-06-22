
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class StudentCourseGroupRelationService : BaseService<StudentCourseGroupRelation>, IStudentCourseGroupRelationService
{
    public StudentCourseGroupRelationService(IStudentCourseGroupRelationRepository repository) : base(repository)
    {
        
    }
}