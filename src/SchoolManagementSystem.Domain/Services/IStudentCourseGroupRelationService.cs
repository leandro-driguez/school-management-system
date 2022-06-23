

using SchoolManagementSystem.Domain.Entities;
using SchoolManagementSystem.Domain.Relations;


namespace SchoolManagementSystem.Domain.Services;

public interface IStudentCourseGroupRelationService : IService<StudentCourseGroupRelation>
{
    public bool ValidateIds(List<string> StudentsId, string courseGroupId, string courseId);
    public void AddStudentsToCourseGroup(List<string> StudentsId, string courseGroupId, string courseId);
    public void DeleteStudentsFromCourseGroup(List<string> StudentsId, string courseGroupId, string courseId);
}