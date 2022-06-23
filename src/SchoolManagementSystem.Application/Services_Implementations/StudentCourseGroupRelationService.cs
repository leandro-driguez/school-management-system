
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Repositories_Interfaces;
using SchoolManagementSystem.Domain.Records;
using SchoolManagementSystem.Domain.Services;
using SchoolManagementSystem.Domain.Relations;

namespace SchoolManagementSystem.Application.Services_Implementations;

public class StudentCourseGroupRelationService : BaseService<StudentCourseGroupRelation>, IStudentCourseGroupRelationService
{
    IStudentCourseGroupRelationRepository repo;
    ICourseGroupRepository cg_repo;
    IStudentRepository st_repo;
    public StudentCourseGroupRelationService(ICourseGroupRepository cg_repo,
            IStudentRepository st_repo,
             IStudentCourseGroupRelationRepository repository) : base(repository)
    {
        this.repo = repository;
        this.cg_repo = cg_repo;
        this.st_repo = st_repo;
    }
    public bool ValidateIds(List<string> StudentsId, string courseGroupId, string courseId)
    {
        var row = cg_repo.Query().Where(c => c.Id == courseGroupId && c.CourseId == courseId)
                            .FirstOrDefault();

        if (row == null)
            return false;
        System.Console.WriteLine("here");
        foreach (var studentId in StudentsId)
        {
            var std = st_repo.Query().Where(c => c.Id == studentId)
                                .FirstOrDefault();
            if (std == null)
                return false;
        }
        System.Console.WriteLine("here2");

        return true;
    }

    public void AddStudentsToCourseGroup(List<string> StudentsId, string courseGroupId, string courseId)
    {
                foreach (var studentId in StudentsId)
            repo.Add(new StudentCourseGroupRelation
            {
                CourseGroupId = courseGroupId,
                StudentId = studentId,
                CourseGroupCourseId = courseId
            });
        repo.CommitAsync();
    }

    public void DeleteStudentsFromCourseGroup(List<string> StudentsId, string courseGroupId, string courseId)
    {
        foreach (var studentId in StudentsId)
        {
            var item = repo.Query().Where(
                    c => c.CourseGroupId == courseGroupId
                    && c.StudentId == studentId
                    && c.CourseGroupCourseId == courseId
            ).FirstOrDefault();
            if(item != null)
                repo.Remove(item);
        }
        repo.CommitAsync();
    }
}