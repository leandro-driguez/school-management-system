
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Relations;
using SchoolManagementSystem.Domain.Interfaces;
using SchoolManagementSystem.Infrastructure.Data;
using SchoolManagementSystem.Infrastructure.Repositories;
using SchoolManagementSystem.Infrastructure.Configurations.Relations;

namespace SchoolManagementSystem.Infrastructure.Repositories
{
    public class StudentCourseGroupRelationRepository :  Base<TeacherPayRecordPerCourse>, ITeacherPayRecordPerCourseRepository
    {
        public StudentCourseGroupRelationRepository(IObjectContext context) : base(context)
        {
     
        }
    }

}
