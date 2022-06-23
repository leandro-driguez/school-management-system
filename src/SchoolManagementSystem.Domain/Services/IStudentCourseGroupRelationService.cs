

using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;


namespace SchoolManagementSystem.Domain.Services;

public interface IStudentCourseGroupRelationService : IService<StudentCourseGroupRelation>
{
    public bool AddStudentToCourseGroup(List<string> StudentsId, string courseGroupId, string courseId);
}